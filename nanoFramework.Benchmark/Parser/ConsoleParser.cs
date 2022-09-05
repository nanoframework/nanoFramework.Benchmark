using nanoFramework.Benchmark.Parser.Abstract;
using nanoFramework.Benchmark.Result;
using System.Reflection;
using System.Text;

namespace nanoFramework.Benchmark.Parser
{
    internal class ConsoleParser : BaseTextParser
    {
        private const string ConsoleTableSeparator = "|";
        private readonly object lockObject = new();
        private int[] columnsSize;
        public override void Parse(SingleBenchmarkResult benchmarkResult)
        {
            lock (lockObject) 
            {
                columnsSize = CalculateColumnSize(benchmarkResult);
                base.Parse(benchmarkResult);
            }
        }

        private int[] CalculateColumnSize(SingleBenchmarkResult benchmarkResult)
        {
            var dataToDisplay = benchmarkResult.GetDataToDisplay();
            int[] columnSizes = new int[dataToDisplay.Length];
            for (int i = 0; i < dataToDisplay.Length; i++)
            {
                var column = dataToDisplay[i];
                var header = GetHeaderFromAttribute(column);
                columnSizes[i] = CalculateColumnSize(column, header, benchmarkResult);
            }

            return columnSizes;
        }

        private static int CalculateColumnSize(MethodInfo method, string header, SingleBenchmarkResult benchmarkResult)
        {
            var size = header.Length;
            for (int i = 0; i < benchmarkResult.MethodResults.Length; i++)
            {
                var parameters = GetParametersForDataMethod(method, i);
                var value = (string)method.Invoke(benchmarkResult, parameters);
                if (value.Length > size)
                {
                    size = value.Length;
                }
            }

            return size;
        }

        protected override string GetParserName(SingleBenchmarkResult benchmarkResult)
        {
            return $"Console export: {benchmarkResult.ClassName} benchmark class.";
        }

        protected override string GetHeader(MethodInfo[] dataToDisplay)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{ConsoleTableSeparator}");
            for (int i = 0; i < dataToDisplay.Length; i++)
            {
                var item = dataToDisplay[i];
                var header = GetHeaderFromAttribute(item);
                stringBuilder.Append(" ");
                stringBuilder.Append(PadRight(header, columnsSize[i]));
                stringBuilder.Append($" {ConsoleTableSeparator}");
            }

            // Create row after header, seperating rows and headers
            var headerLength = stringBuilder.Length;
            stringBuilder.AppendLine();
            stringBuilder.Append($"{ConsoleTableSeparator} ");
            // -4 characters = '| ' + ' |'
            for (int i = 0; i < headerLength - 4; i++)
            {
                stringBuilder.Append("-");
            }
            stringBuilder.Append($" {ConsoleTableSeparator}");

            return stringBuilder.ToString();
        }

        protected override string GetRow(SingleBenchmarkResult item, MethodInfo[] dataToDisplay, int rowIndex)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{ConsoleTableSeparator}");
            for (int i = 0; i < dataToDisplay.Length; i++)
            {
                var dataMethod = dataToDisplay[i];
                var rowData = GetDataFromDataMethod(item, dataMethod, rowIndex);
                stringBuilder.Append($" ");
                stringBuilder.Append(PadRight(rowData, columnsSize[i]));
                stringBuilder.Append($" {ConsoleTableSeparator}");
            }

            return stringBuilder.ToString();
        }
    }
}
