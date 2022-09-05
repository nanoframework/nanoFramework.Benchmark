using System;

namespace nanoFramework.Benchmark
{
    /// <summary>
    /// Specify benchmark method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class BenchmarkAttribute : Attribute
    {
    }
}
