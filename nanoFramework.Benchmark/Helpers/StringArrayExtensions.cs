using System;

namespace nanoFramework.Benchmark.Helpers
{
    internal static class StringArrayExtensions
    {
        internal static bool Contains(this string[] array, string item)
        {
            foreach (var arrayItem in array)
            {
                if (arrayItem == item)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
