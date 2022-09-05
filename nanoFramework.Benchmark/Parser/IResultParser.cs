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
