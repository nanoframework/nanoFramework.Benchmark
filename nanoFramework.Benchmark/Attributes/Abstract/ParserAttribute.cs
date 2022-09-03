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

        // Invoked via reflection!
        internal IResultParser ResultParser
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

        internal abstract IResultParser CreateNewResultParser { get; }
    }
}
