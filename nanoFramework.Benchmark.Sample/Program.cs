////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;
using System.Diagnostics;
using System.Threading;

namespace nanoFramework.Benchmark.Sample
{
    public static class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework.Benchmark!");

            BenchmarkRunner.Run(typeof(IAssemblyHandler).Assembly);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
