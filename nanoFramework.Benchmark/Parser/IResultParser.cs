////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using nanoFramework.Benchmark.Result;
using System;

namespace nanoFramework.Benchmark.Parser
{
    /// <summary>
    /// Base interface for result parsers.
    /// </summary>
    interface IResultParser
    {
        void Parse(SingleBenchmarkResult benchmarkResult);
    }
}
