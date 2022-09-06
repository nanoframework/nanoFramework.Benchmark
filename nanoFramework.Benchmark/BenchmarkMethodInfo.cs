////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System.Reflection;

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
