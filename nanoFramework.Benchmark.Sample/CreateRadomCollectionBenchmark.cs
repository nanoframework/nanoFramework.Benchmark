////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;
using System.Collections;
using nanoFramework.Benchmark.Attributes;
using nanoFramework.Logging.Debug;

namespace nanoFramework.Benchmark.Sample
{
    [IterationCount(11)]
    [DebugLogger]
    [CsvParser]
    [ConsoleParser]
    public class CreateRadomCollectionBenchmark
    {
        public int NumbersToCreateCount { get; set; } = 1000;

        private Random random;

        [Setup]
        public void Setup()
        {
            random = new Random();
        }

        [Benchmark]
        public void CreateRandomArray()
        {
            var arrayOfInts = new int[NumbersToCreateCount];
            for (int i = 0; i < NumbersToCreateCount; i++)
            {
                var value = random.Next();
                arrayOfInts[i] = value;
            }
        }

        [Benchmark]
        public void CreateRandomList()
        {
            var listOfInts = new ArrayList();
            for (int i = 0; i < NumbersToCreateCount; i++)
            {
                var value = random.Next();
                listOfInts.Add(value);
            }
        }
    }
}
