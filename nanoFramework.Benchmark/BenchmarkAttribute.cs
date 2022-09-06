////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;

namespace nanoFramework.Benchmark
{
    /// <summary>
    /// Specify benchmark method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class BenchmarkAttribute : Attribute
    {
    }
}
