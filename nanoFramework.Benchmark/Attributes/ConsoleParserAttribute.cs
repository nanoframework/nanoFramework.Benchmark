using nanoFramework.Benchmark.Attributes.Abstract;
using nanoFramework.Benchmark.Parser;
using System;

namespace nanoFramework.Benchmark.Attributes
{
    /// <summary>
    /// Adds parser that prints benchmark outputs in console as table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ConsoleParserAttribute : ParserAttribute
    {

        /// <summary>
        /// Creates new instance of Console parser. 
        /// </summary>
        public override IResultParser CreateNewResultParser => new ConsoleParser();
    }
}