using nanoFramework.Benchmark.Parser;
using System;

namespace nanoFramework.Benchmark.Attributes.Abstract
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class ParserAttribute : Attribute
    {
        private static IResultParser parser;
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

        public abstract IResultParser CreateNewResultParser { get; }
    }
}
