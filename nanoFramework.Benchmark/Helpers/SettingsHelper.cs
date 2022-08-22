﻿using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Attributes;
using nanoFramework.Benchmark.Parser;
using System;
using System.Reflection;

namespace nanoFramework.Benchmark.Helpers
{
    internal class SettingsHelper
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

        internal static int GetItterationCount(Type benchmarkClass)
        {
            var attribute = ReflectionHelpers.GetFirstOrDefaultAttribute(benchmarkClass, typeof(IterationCountAttribute));
            if (attribute != null && attribute is IterationCountAttribute itterationCountAttribute)
            {
                return itterationCountAttribute.Count;
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
