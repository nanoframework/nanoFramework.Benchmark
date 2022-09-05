using nanoFramework.Benchmark.Helpers;
using nanoFramework.Benchmark.Result.Attributes;
using nanoFramework.Benchmark.Result;
using System.Collections;
using System.Reflection;

namespace nanoFramework.Benchmark.Parser.Abstract
{
    internal abstract class BaseParser : IResultParser
    {
        public abstract void Parse(SingleBenchmarkResult benchmarkResult);

        protected static MethodInfo[] GetMethodsToDisplay()
        {
            var tempList = new ArrayList();
            var allMethods = typeof(SingleBenchmarkResult).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in allMethods)
            {
                var displayAttrib = ReflectionHelpers.GetFirstOrDefaultAttribute(method, typeof(DisplayAttribute));
                if (displayAttrib == null)
                {
                    continue;
                }

                tempList.Add(method);
            }

            return ArrayListHelper.ConvertFromArrayListToMethodInfoArray(tempList);
        }
    }
}
