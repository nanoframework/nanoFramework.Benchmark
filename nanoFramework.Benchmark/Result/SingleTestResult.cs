using System;

namespace nanoFramework.Benchmark.Result
{
    public sealed class SingleTestResult
    {
        public TimeSpan ElapsedTime { get; }

        public SingleTestResult(TimeSpan elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }
    }
}
