////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;

namespace nanoFramework.Benchmark.Result
{
    internal sealed class SingleTestResult
    {
        public TimeSpan ElapsedTime { get; }

        public SingleTestResult(TimeSpan elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }
    }
}
