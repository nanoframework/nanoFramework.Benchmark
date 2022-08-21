using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Attributes.Abstract;
using nanoFramework.Logging.Debug;
using System;

namespace nanoFramework.Benchmark.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class DebugLoggerAttribute : LoggerAttribute
    {
        const string DebugLoggerCategory = "DebugLogger";

        private static ILogger logger;
        public override ILogger Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = new DebugLoggerFactory().CreateLogger(DebugLoggerCategory);
                }

                return logger;
            }
        }
    }
}
