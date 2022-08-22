﻿using nanoFramework.Benchmark.Parser;
using nanoFramework.Benchmark.Result;
using System;
using System.Collections;
using System.Reflection;

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