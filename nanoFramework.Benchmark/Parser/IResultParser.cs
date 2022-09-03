using nanoFramework.Benchmark.Result;
using System;

namespace nanoFramework.Benchmark.Parser
{
    /// <summary>
    /// Base interface for reult parsers.
    /// </summary>
    interface IResultParser
    {
        void Parse(SingleBenchmarkResult benchmarkResult);
    }
}
