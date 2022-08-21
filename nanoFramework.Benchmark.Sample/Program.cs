using System;
using System.Diagnostics;
using System.Threading;

namespace nanoFramework.Benchmark.Sample
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework.Benchmark!");

            BenchmarkRunner.Run(typeof(IAssemblyHandler).Assembly);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
