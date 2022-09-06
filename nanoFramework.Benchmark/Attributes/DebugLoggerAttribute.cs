////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;
using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Attributes.Abstract;
using nanoFramework.Logging.Debug;

namespace nanoFramework.Benchmark.Attributes
{
    /// <summary>
    /// Adds debugg logger. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class DebugLoggerAttribute : LoggerAttribute
    {
        private const string DebugLoggerCategory = "DebugLogger";

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
