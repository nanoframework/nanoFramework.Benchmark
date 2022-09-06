////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using nanoFramework.Benchmark.Result.Attributes;

namespace nanoFramework.Benchmark.Result
{
    internal class SingleBenchmarkResult
    {
        public MethodResult[] MethodResults { get; }
        public string ClassName { get; }
        public int ItterationCount { get; }

        public SingleBenchmarkResult(MethodResult[] methodResults, string className, int itterationCount)
        {
            MethodResults = methodResults;
            ClassName = className;
            ItterationCount = itterationCount;
        }

        [Display("MethodName")]
        public string MethodName(int index)
        {
            return MethodResults[index].GetMethodName();
        }

        [Display("ItterationCount")]
        public string ItterationCountMethod()
        {
            return ItterationCount.ToString();
        }

        [Display("Mean")]
        public string MeanExecutionTime(int index)
        {
            return MethodResults[index].GetMeanExecutionTime();
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
    }
}
