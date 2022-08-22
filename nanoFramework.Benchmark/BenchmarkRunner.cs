﻿using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Helpers;
using nanoFramework.Benchmark.Parser;
using nanoFramework.Benchmark.Result;
using System;
using System.Collections;
using System.Reflection;

namespace nanoFramework.Benchmark
{
    public static class BenchmarkRunner
    {
        private static string[] ExcludedClassNamesFromBenchmarks =
        {
            "Program"
        };

        public static void Run(Assembly assembly)
        {
            var classes = assembly.GetTypes();
            foreach (var type in classes)
            {
                if (!type.IsClass)
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

        public static void RunClass(Type classType)
        {
            if (!classType.IsClass)
                throw new InvalidOperationException();

            if (classType.IsAbstract)
                throw new InvalidOperationException();

            #region SetupRunner
            var itterationCount = SettingsHelper.GetItterationCount(classType);
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
            foreach (MethodInfo method in ReflectionHelpers.GetBenchmarkMethods(allMethods, logger))
            {
                var result = Run(classToInvokeMethodOn, method, itterationCount);
                methodResults.Add(new MethodResult(method.Name, result));
            }

            var benchmarkResult = new SingleBenchmarkResult(
                ArrayListHelper.ConvertFromArrayListToMethodResultArray(methodResults), 
                classType.Name, 
                itterationCount);

            InvokeParses(benchmarkResult, parsers, logger);
        }

        private static SingleTestResult[] Run(object classToInvokeMethodOn, MethodInfo method, int itterationCount)
        {
            var resultCollection = new SingleTestResult[itterationCount];

            // There is a check if method has no parameters before
            var parameters = new object[0];

            for (var i = 0; i < itterationCount; i++)
            {
                var startTime = Environment.TickCount64;
                method.Invoke(classToInvokeMethodOn, parameters);
                var endTime = Environment.TickCount64;
                resultCollection[i] = new SingleTestResult(TimeSpan.FromMilliseconds(endTime - startTime));
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