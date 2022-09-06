////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System.Collections;
using System.Reflection;
using nanoFramework.Benchmark.Parser;
using nanoFramework.Benchmark.Result;

namespace nanoFramework.Benchmark.Helpers
{
    internal static class ArrayListHelper
    {
        internal static MethodResult[] ConvertFromArrayListToMethodResultArray(ArrayList arrayList)
        {
            var result = new MethodResult[arrayList.Count];
            for (int i = 0; i < arrayList.Count; i++)
            {
                result[i] = (MethodResult)arrayList[i];
            }

            return result;
        }

        internal static MethodInfo[] ConvertFromArrayListToMethodInfoArray(ArrayList arrayList)
        {
            var result = new MethodInfo[arrayList.Count];
            for (int i = 0; i < arrayList.Count; i++)
            {
                result[i] = (MethodInfo)arrayList[i];
            }

            return result;
        }

        internal static BenchmarkMethodInfo[] ConvertFromArrayListToBenchmarkMethodInfoArray(ArrayList arrayList)
        {
            var result = new BenchmarkMethodInfo[arrayList.Count];
            for (int i = 0; i < arrayList.Count; i++)
            {
                result[i] = (BenchmarkMethodInfo)arrayList[i];
            }

            return result;
        }

        internal static IResultParser[] ConvertFromArrayListToIResultParserArray(ArrayList arrayList)
        {
            var result = new IResultParser[arrayList.Count];
            for (int i = 0; i < arrayList.Count; i++)
            {
                result[i] = (IResultParser)arrayList[i];
            }

            return result;
        }
    }
}
