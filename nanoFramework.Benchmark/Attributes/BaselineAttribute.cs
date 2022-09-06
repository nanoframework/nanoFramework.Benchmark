////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;

namespace nanoFramework.Benchmark.Attributes
{
    /// <summary>
    /// Specifies method which should be considered as baseline for calculation. Add new column "Ratio" to output.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class BaselineAttribute : Attribute
    {
    }
}
