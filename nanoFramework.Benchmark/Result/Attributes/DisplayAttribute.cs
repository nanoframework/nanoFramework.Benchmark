////
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
////

using System;

namespace nanoFramework.Benchmark.Result.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal sealed class DisplayAttribute : Attribute
    {
        public string Header { get; }

        public DisplayAttribute(string header)
        {
            Header = header;
        }
    }
}
