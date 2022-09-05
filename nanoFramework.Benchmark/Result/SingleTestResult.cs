using System;

namespace nanoFramework.Benchmark.Result
{
    sealed class SingleTestResult
    {
        public TimeSpan ElapsedTime { get; }

        public SingleTestResult(TimeSpan elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }
    }
}
