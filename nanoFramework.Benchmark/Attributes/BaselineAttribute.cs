using System;
using System.Text;

namespace nanoFramework.Benchmark.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class BaselineAttribute : Attribute
    {
    }
}
