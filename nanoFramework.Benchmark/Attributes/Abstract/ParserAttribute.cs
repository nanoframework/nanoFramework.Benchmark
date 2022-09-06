////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;
using nanoFramework.Benchmark.Parser;

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
