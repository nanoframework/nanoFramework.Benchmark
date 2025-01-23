////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;
using System.Reflection;
using System.Text;
using nanoFramework.Benchmark.Helpers;
using nanoFramework.Benchmark.Result;
using nanoFramework.Benchmark.Result.Attributes;

namespace nanoFramework.Benchmark.Parser.Abstract
{
    internal abstract class BaseTextParser : IResultParser
    {
        protected static string GetHeaderFromAttribute(MethodInfo methodInfo)
        {
            // At this point all passed MethodsInfo should be properties and should have Display attribute
            return ((DisplayAttribute)ReflectionHelpers.GetFirstAttribute(methodInfo, typeof(DisplayAttribute))).Header;
        }

        protected static string PadRight(string value, int toLenght)
        {
            var builder = new StringBuilder(value);
            for (int j = 0; j < toLenght - value.Length; j++)
            {
                builder.Append(" ");
            }

            return builder.ToString();
        }

        protected static object[] GetParametersForDataMethod(MethodInfo dataMethod, int rowIndex)
        {
            var parametersCount = dataMethod.GetParameters().Length;
            if (parametersCount == 0)
            {
                return new object[0];
            }

            if (parametersCount == 1)
            {
                return new object[] { rowIndex };
            }

            throw new InvalidOperationException();
        }

        protected abstract string GetParserName(SingleBenchmarkResult benchmarkResult);

        protected abstract string GetHeader(MethodInfo[] dataToDisplay);

        protected abstract string GetRow(SingleBenchmarkResult item, MethodInfo[] dataToDisplay, int rowIndex);

        protected abstract string GetRowSeparator();

        protected virtual void PrintLine(string value)
        {
            Console.WriteLine(value);
        }

        protected string GetDataFromDataMethod(SingleBenchmarkResult item, MethodInfo dataMethod, int rowIndex)
        {
            var parameters = GetParametersForDataMethod(dataMethod, rowIndex);
            return (string)dataMethod.Invoke(item, parameters);
        }

        public virtual void Parse(SingleBenchmarkResult benchmarkResult)
        {
            PrintLine(string.Empty);
            PrintLine(string.Empty);
            PrintLine(GetParserName(benchmarkResult));
            PrintLine(string.Empty);

            var dataToDisplay = benchmarkResult.GetDataToDisplay();

            PrintLine(GetRowSeparator());

            PrintLine(GetHeader(dataToDisplay));

            for (int i = 0; i < benchmarkResult.MethodResults.Length; i++)
            {
                PrintLine(GetRow(benchmarkResult, dataToDisplay, i));
            }

            PrintLine(GetRowSeparator());
        }
    }
}
