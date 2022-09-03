using nanoFramework.Benchmark.Parser;
using System;

namespace nanoFramework.Benchmark.Attributes.Abstract
{
    /// <summary>
    /// Base class for parser.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class ParserAttribute : Attribute
    {
        private IResultParser parser;

        /// <summary>
        /// Gets instance of parser.
        /// </summary>
        public IResultParser ResultParser
        {
            get
            {
                if (parser == null)
                {
                    parser = CreateNewResultParser;
                }

                return parser;
            }
        }

        /// <summary>
        /// Creates new instance of parser.
        /// </summary>
        public abstract IResultParser CreateNewResultParser { get; }
    }
}
