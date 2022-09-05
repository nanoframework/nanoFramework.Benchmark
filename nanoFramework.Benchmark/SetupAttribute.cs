using System;

namespace nanoFramework.Benchmark
{
    /// <summary>
    /// Specifies a method that is invoked only once before running benchmark methods. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SetupAttribute : Attribute
    {
    }
}
