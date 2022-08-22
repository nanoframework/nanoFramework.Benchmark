using System;

namespace nanoFramework.Benchmark.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class IterationCountAttribute : Attribute
    {
        public const ushort DefaultIterationCount = 10;

        public int Count { get; }

        public IterationCountAttribute(int count)
        {
            Count = count;
        }
    }
}
