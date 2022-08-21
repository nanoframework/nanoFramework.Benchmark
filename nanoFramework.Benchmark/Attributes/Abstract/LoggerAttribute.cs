using Microsoft.Extensions.Logging;
using System;

namespace nanoFramework.Benchmark.Attributes.Abstract
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class LoggerAttribute : Attribute
    {
        public abstract ILogger Logger { get; }
    }
}
