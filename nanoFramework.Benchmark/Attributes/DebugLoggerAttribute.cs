using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Attributes.Abstract;
using nanoFramework.Logging.Debug;
using System;

namespace nanoFramework.Benchmark.Attributes
{
    /// <summary>
    /// Adds debugg logger. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class DebugLoggerAttribute : LoggerAttribute
    {
        const string DebugLoggerCategory = "DebugLogger";

        private ILogger logger;

        /// <summary>
        /// Gets instance of logger.
        /// </summary>
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
