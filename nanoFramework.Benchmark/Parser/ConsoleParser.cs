////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System.Reflection;
using System.Text;
using nanoFramework.Benchmark.Parser.Abstract;
using nanoFramework.Benchmark.Result;

namespace nanoFramework.Benchmark.Parser
{
    internal class ConsoleParser : BaseTextParser
    {
        private const string ConsoleTableSeparator = "|";
        private readonly object lockObject = new ();
        private int[] columnsSize;
        private string _tableSeparator;

        public override void Parse(SingleBenchmarkResult benchmarkResult)
        {
            lock (lockObject)
            {
                columnsSize = CalculateColumnSize(benchmarkResult);
                _tableSeparator = null;

                base.Parse(benchmarkResult);
            }
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

        protected override string GetParserName(SingleBenchmarkResult benchmarkResult)
        {
            return $"Console export: {benchmarkResult.ClassName} benchmark class.";
        }

        protected override string GetHeader(MethodInfo[] dataToDisplay)
        {
            var stringBuilder = new StringBuilder();

            // append column headers
            stringBuilder.Append($"{ConsoleTableSeparator}");

            for (int i = 0; i < dataToDisplay.Length; i++)
            {
                var item = dataToDisplay[i];
                var header = GetHeaderFromAttribute(item);
                stringBuilder.Append(" ");
                stringBuilder.Append(PadRight(header, columnsSize[i]));
                stringBuilder.Append($" {ConsoleTableSeparator}");
            }

            stringBuilder.AppendLine();

            // append table separator to end the header
            stringBuilder.Append(GetRowSeparator());

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

        protected override string GetRowSeparator()
        {
            if (_tableSeparator == null)
            {
                StringBuilder stringBuilder = new ();

                // compute total header length from all columns
                int headerLength = 0;
                for (int i = 0; i < columnsSize.Length; i++)
                {
                    // account for the space between columns and the separator
                    headerLength += columnsSize[i] + 3;
                }

                stringBuilder.Append($"{ConsoleTableSeparator} ");

                // account for the separator and the space at the end (twice)
                for (int i = 0; i < headerLength - 3; i++)
                {
                    stringBuilder.Append("-");
                }

                stringBuilder.Append($" {ConsoleTableSeparator}");
                _tableSeparator = stringBuilder.ToString();
            }

            return _tableSeparator;
        }
    }
}
