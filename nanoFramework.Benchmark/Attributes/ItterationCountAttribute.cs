using System;

namespace nanoFramework.Benchmark.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ItterationCountAttribute : Attribute
    {
        public const ushort DefaultItterationCount = 10;

        public int Count { get; }

        public ItterationCountAttribute(int count)
        {
            Count = count;
        }
    }
}
