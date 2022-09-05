using nanoFramework.Benchmark.Parser.Abstract;
using nanoFramework.Benchmark.Result;
using System.Reflection;
using System.Text;

namespace nanoFramework.Benchmark.Parser
{
    internal class CsvParser : BaseTextParser
    {
        private const char ValuesSeparator = ';';

        protected override string GetParserName(SingleBenchmarkResult benchmarkResult)
        {
            return $"CSV export: {benchmarkResult.ClassName} benchmark class.";
        }

        protected override string GetHeader(MethodInfo[] dataToDisplay)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < dataToDisplay.Length; i++)
            {
                var item = dataToDisplay[i];
                var header = GetHeaderFromAttribute(item);
                stringBuilder.Append(header);

                if (i < dataToDisplay.Length - 1)
                {
                    stringBuilder.Append($"{ValuesSeparator}");
                }
            }

            return stringBuilder.ToString();
        }

        protected override string GetRow(SingleBenchmarkResult item, MethodInfo[] dataToDisplay, int rowIndex)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < dataToDisplay.Length; i++)
            {
                var dataMethod = dataToDisplay[i];
                var rowData = GetDataFromDataMethod(item, dataMethod, rowIndex);
                stringBuilder.Append(rowData);

                if (i < dataToDisplay.Length - 1)
                {
                    stringBuilder.Append($"{ValuesSeparator}");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
