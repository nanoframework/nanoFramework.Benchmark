using System;

namespace nanoFramework.Benchmark.Result.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    sealed class DisplayAttribute : Attribute
    {
        public string Header { get; }

        public DisplayAttribute(string header)
        {
            Header = header;
        }
    }
}
