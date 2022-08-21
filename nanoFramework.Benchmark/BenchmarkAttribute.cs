using System;

namespace nanoFramework.Benchmark
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class BenchmarkAttribute : Attribute
    {
    }
}
