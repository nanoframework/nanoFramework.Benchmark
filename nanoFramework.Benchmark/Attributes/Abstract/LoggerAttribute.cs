////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using Microsoft.Extensions.Logging;
using System;

namespace nanoFramework.Benchmark.Attributes.Abstract
{
    /// <summary>
    /// Base class for loggers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class LoggerAttribute : Attribute
    {
        /// <summary>
        /// Gets instance of logger.
        /// </summary>
        public abstract ILogger Logger { get; }
    }
}
