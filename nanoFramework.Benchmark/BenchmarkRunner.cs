using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Helpers;
using nanoFramework.Benchmark.Parser;
using nanoFramework.Benchmark.Result;
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace nanoFramework.Benchmark
{
    /// <summary>
    /// Main runner class.
    /// </summary>
    public static class BenchmarkRunner
    {
        private static string[] ExcludedClassNamesFromBenchmarks =
        {
            "Program"
        };

        /// <summary>
        /// Runs all benchmarks from assembly. 
        /// </summary>
        /// <param name="assembly">Assembly with benchmarks.</param>
        public static void Run(Assembly assembly)
        {
            var classes = assembly.GetTypes();
            foreach (var type in classes)
            {
                if (!type.IsClass)
                {
                    continue;
                }

                if (!type.IsPublic)
                {
                    continue;
                }

                if (type.IsInterface)
                {
                    continue;
                }

                if (type.IsAbstract)
                {
                    continue;
                }
                
                if (ExcludedClassNamesFromBenchmarks.Contains(type.Name))
                {
                    continue;
                }

                RunClass(type);
            }
        }

        /// <summary>
        /// Runs all benchmarks from class.
        /// </summary>
        /// <param name="classType">Class with benchmarks.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void RunClass(Type classType)
        {
            if (!classType.IsClass)
                throw new InvalidOperationException();

            if (classType.IsAbstract)
                throw new InvalidOperationException();

            #region SetupRunner
            var iterationCount = SettingsHelper.GetItterationCount(classType);
            var logger = SettingsHelper.GetLoggerIfExists(classType);
            var parsers = SettingsHelper.GetResultParser(classType);
            #endregion

            var classToInvokeMethodOn = ReflectionHelpers.CreateObjectViaReflection(classType);
            if (classToInvokeMethodOn == null)
            {
                logger?.LogError($"Unable to create instance of {classType.FullName} class. Make sure that class contains parameterless constructor.");
                return;
            }

            var allMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var setupMethod = (MethodInfo)ReflectionHelpers.GetSetupMethodIfExists(allMethods);
            setupMethod?.Invoke(classToInvokeMethodOn, null);

            var methodResults = new ArrayList();
            var hasBaseline = false;
            foreach (BenchmarkMethodInfo method in ReflectionHelpers.GetBenchmarkMethods(allMethods, logger))
            {
                var result = Run(classToInvokeMethodOn, method.MethodInfo, iterationCount);
                methodResults.Add(new MethodResult(method.MethodInfo.Name, result, method.IsBaseline));

                if (!hasBaseline && method.IsBaseline)
                {
                    hasBaseline = true;
                }
            }

            var benchmarkResult = new SingleBenchmarkResult(
                ArrayListHelper.ConvertFromArrayListToMethodResultArray(methodResults), 
                classType.Name, 
                iterationCount,
                hasBaseline);

            InvokeParses(benchmarkResult, parsers, logger);
        }

        private static SingleTestResult[] Run(object classToInvokeMethodOn, MethodInfo method, int itterationCount)
        {
            var resultCollection = new SingleTestResult[itterationCount];

            // There is a check if method has no parameters before
            var parameters = new object[0];

            var watch = new Stopwatch();
            for (var i = 0; i < itterationCount; i++)
            {
                watch.Restart();
                method.Invoke(classToInvokeMethodOn, parameters);
                watch.Stop();
                resultCollection[i] = new SingleTestResult(watch.Elapsed);
            }

            return resultCollection;
        }

        private static void InvokeParses(SingleBenchmarkResult benchmarkResult, IResultParser[] Parsers, ILogger logger)
        {
            if (benchmarkResult.MethodResults.Length == 0)
            {
                logger?.LogWarning($"No result found from {benchmarkResult.ClassName} class.");
            }

            foreach (var parser in Parsers)
            {
                parser.Parse(benchmarkResult);
            }
        }
    }
}
