////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;

namespace nanoFramework.Benchmark.Attributes
{
    /// <summary>
    /// Specifies samples count for each benchmark.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class IterationCountAttribute : Attribute
    {
        /// <summary>
        /// Default samples count when attribute is not added.
        /// </summary>
        public const ushort DefaultIterationCount = 10;

        /// <summary>
        /// Gets samples count.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IterationCountAttribute" /> class.
        /// </summary>
        /// <param name="count">Samples count.</param>
        public IterationCountAttribute(int count)
        {
            Count = count;
        }
    }
}
