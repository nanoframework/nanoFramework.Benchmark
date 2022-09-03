using System;
using System.Reflection;
using System.Text;

namespace nanoFramework.Benchmark
{
    internal sealed class BenchmarkMethodInfo
    {
        public MethodInfo MethodInfo { get; }
        public bool IsBaseline { get; }

        public BenchmarkMethodInfo(MethodInfo methodInfo, bool isBaseline)
        {
            MethodInfo = methodInfo;
            IsBaseline = isBaseline;
        }
    }
}
