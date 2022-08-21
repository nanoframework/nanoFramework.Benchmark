using nanoFramework.Benchmark.Attributes.Abstract;
using nanoFramework.Benchmark.Parser;
using System;

namespace nanoFramework.Benchmark.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class CsvParserAttribute : ParserAttribute
    {
        public override IResultParser CreateNewResultParser => new CsvParser();
    }
}