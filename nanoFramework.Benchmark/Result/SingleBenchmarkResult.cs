using nanoFramework.Benchmark.Helpers;
using nanoFramework.Benchmark.Result.Attributes;
using System.Collections;
using System.Reflection;

namespace nanoFramework.Benchmark.Result
{
    public class SingleBenchmarkResult
    {
        public MethodResult[] MethodResults { get; }
        public string ClassName { get; }
        public int ItterationCount { get; }

        public SingleBenchmarkResult(MethodResult[] methodResults, string className, int itterationCount)
        {
            MethodResults = methodResults;
            ClassName = className;
            ItterationCount = itterationCount;
        }

        [Display("MethodName")]
        public string MethodName(int index)
        {
            return MethodResults[index].GetMethodName();
        }

        [Display("ItterationCount")]
        public string ItterationCountMethod()
        {
            return ItterationCount.ToString();
        }

        [Display("Mean")]
        public string MeanExecutionTime(int index)
        {
            return MethodResults[index].GetMeanExecutionTime();
        }

        [Display("Min")]
        public string MinExecutionTime(int index)
        {
            return MethodResults[index].GetMinExecutionTime();
        }

        [Display("Max")]
        public string MaxExecutionTime(int index)
        {
            return MethodResults[index].GetMaxExecutionTime();
        }

        // TODO: Move to helper class
        internal static MethodInfo[] GetDataToDisplay()
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
