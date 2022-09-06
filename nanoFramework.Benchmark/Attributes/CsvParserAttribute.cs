////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

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
        internal override IResultParser CreateNewResultParser => new CsvParser();
    }
}