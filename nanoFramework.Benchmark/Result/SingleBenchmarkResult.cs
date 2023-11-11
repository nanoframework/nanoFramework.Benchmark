////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using nanoFramework.Benchmark.Result.Attributes;
﻿using nanoFramework.Benchmark.Helpers;
using System.Collections;
using System.Reflection;

namespace nanoFramework.Benchmark.Result
{
    internal class SingleBenchmarkResult
    {
        public MethodResult[] MethodResults { get; }
        public string ClassName { get; }
        public int IterationCount { get; }
        public bool ShouldCalculateRatio { get; }

        public SingleBenchmarkResult(MethodResult[] methodResults, string className, int iterationCount, bool shouldCalculateRatio)
        {
            MethodResults = methodResults;
            ClassName = className;
            IterationCount = iterationCount;
            ShouldCalculateRatio = shouldCalculateRatio;
        }

        [Display("MethodName")]
        public string MethodName(int index)
        {
            return MethodResults[index].GetMethodName();
        }

        [Display("IterationCount")]
        public string IterationCountMethod()
        {
            return IterationCount.ToString();
        }

        [Display("Mean")]
        public string MeanExecutionTime(int index)
        {
            return MethodResults[index].GetMeanExecutionTime();
        }

        [Display("Ratio")]
        public string Ratio(int index)
        {
            var isBaseline = MethodResults[index].IsBaseline;
            if (isBaseline)
            {
                return "1.0";
            }

            var baseLineResult = ArrayHelper.FindBaseLine(MethodResults).GetMeanExecutionTimeRaw();
            var currentResult = MethodResults[index].GetMeanExecutionTimeRaw();

            return $"{((float)currentResult.Ticks / baseLineResult.Ticks):N4}";
        }

        [Display("Min")]
        public string MinExecutionTime(int index)
        {
            return MethodResults[index].GetMinExecutionTime();
        }

        [Display("Max")]
        public string MaxExecutionTime(int index)
        {
            return MethodResults[index].GetMaxExecutionTime();
        }

        /// <summary>
        /// Gets methods with data based on configuration.
        /// </summary>
        /// <returns>All methods which will be used in parsers.</returns>
        internal MethodInfo[] GetDataToDisplay()
        {
            var tempList = new ArrayList();
            var allMethods = typeof(SingleBenchmarkResult).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in allMethods)
            {
                var displayAttrib = ReflectionHelpers.GetFirstOrDefaultAttribute(method, typeof(DisplayAttribute));
                if (displayAttrib == null)
                {
                    continue;
                }

                if (method.Name == nameof(Ratio) && !ShouldCalculateRatio)
                {
                    continue;
                }

                tempList.Add(method);
            }

            return ArrayListHelper.ConvertFromArrayListToMethodInfoArray(tempList);
        }
    }
}
