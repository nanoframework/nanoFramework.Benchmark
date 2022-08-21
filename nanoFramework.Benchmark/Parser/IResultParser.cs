using nanoFramework.Benchmark.Result;
using System;

namespace nanoFramework.Benchmark.Parser
{
    public interface IResultParser
    {
        void Parse(SingleBenchmarkResult benchmarkResult);
    }
}
