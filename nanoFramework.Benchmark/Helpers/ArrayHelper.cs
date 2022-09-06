using nanoFramework.Benchmark.Result;
using System;
using System.Reflection;
using System.Text;

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
