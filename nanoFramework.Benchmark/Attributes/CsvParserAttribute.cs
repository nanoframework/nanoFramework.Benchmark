using nanoFramework.Benchmark.Attributes.Abstract;
using nanoFramework.Benchmark.Parser;
using System;

namespace nanoFramework.Benchmark.Attributes
{
    /// <summary>
    /// Adds parser that prints benchmark outputs in console in csv format.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class CsvParserAttribute : ParserAttribute
    {
        /// <summary>
        ///  Create bew instance of CsvParser.
        /// </summary>
        public override IResultParser CreateNewResultParser => new CsvParser();
    }
}