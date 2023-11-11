////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;
using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Attributes;
using nanoFramework.Benchmark.Parser;

namespace nanoFramework.Benchmark.Helpers
{
    internal static class SettingsHelper
    {
        private static IResultParser[] defaultParsers;

        private static IResultParser[] DefaultParsers
        {
            get
            {
                if (defaultParsers == null)
                {
                    defaultParsers = new IResultParser[]
                    {
                        new ConsoleParser()
                    };
                }

                return defaultParsers;
            }
        }

        internal static ILogger GetLoggerIfExists(Type classType)
        {
            return (ILogger)ReflectionHelpers.GetObjectInstanceFromAttributesIfExists(classType, typeof(ILogger));
        }

        internal static int GetIterationCount(Type benchmarkClass)
        {
            var attribute = ReflectionHelpers.GetFirstOrDefaultAttribute(benchmarkClass, typeof(IterationCountAttribute));
            if (attribute is IterationCountAttribute iterationCountAttribute)
            {
                return iterationCountAttribute.Count;
            }

            return IterationCountAttribute.DefaultIterationCount;
        }

        internal static IResultParser[] GetResultParser(Type classType)
        {
            var parsers = ReflectionHelpers.GetObjectsInstanceFromAttributesIfExists(classType, typeof(IResultParser));
            if (parsers != null && parsers.Count != 0)
            {
                return ArrayListHelper.ConvertFromArrayListToIResultParserArray(parsers);
            }

            return DefaultParsers;
        }
    }
}
