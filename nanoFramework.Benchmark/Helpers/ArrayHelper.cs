////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;
using System.Reflection;
using System.Text;
using nanoFramework.Benchmark.Result;

namespace nanoFramework.Benchmark.Helpers
{
    internal static class ArrayHelper
    {
        internal static MethodResult FindBaseLine(MethodResult[] methodResults)
        {
            foreach (var item in methodResults)
            {
                if (item.IsBaseline)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
