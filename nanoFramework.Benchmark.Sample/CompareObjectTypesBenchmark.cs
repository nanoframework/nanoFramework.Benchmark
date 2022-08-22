using nanoFramework.Benchmark.Attributes;
using System;

namespace nanoFramework.Benchmark.Sample
{
    [CsvParser]
    [ConsoleParser]
    [ItterationCount(100)]
    public class CompareObjectTypesBenchmark
    {
        object[] array;

        [Setup]
        public void SetUp()
        {
            array = new object[] {
                        (int)42,
                        (byte)42,
                        "This is a super string",
                        (ulong)42,
                        new Version(4, 2)
                    };
        }

        [Benchmark]
        public void CompareByString()
        {
            for (int i = 0; i < array.Length; i++)
            {
                object obja = array.GetValue(i);
                var typea = obja.GetType();
                CompareUsingString(typea);
            }
        }

        [Benchmark]
        public void CompareUsingTypeofIf()
        {
            for (int i = 0; i < array.Length; i++)
            {
                object obja = array.GetValue(i);
                var typea = obja.GetType();

                CompareUsingTypeofIf(typea);
            }
        }

        [Benchmark]
        public void CompareUsingTypeofIfReturn()
        {
            for (int i = 0; i < array.Length; i++)
            {
                object obja = array.GetValue(i);
                var typea = obja.GetType();

                CompareUsingTypeofIfReturn(typea);
            }
        }

        void CompareUsingString(Type typea)
        {
            switch (typea.FullName)
            {
                case "System.Int32":
                    Console.WriteLine("System.Int32");
                    break;
                case "System.UInt32":
                    Console.WriteLine("System.UInt32");
                    break;
                case "System.Byte":
                    Console.WriteLine("System.Byte");
                    break;
                case "System.SByte":
                    Console.WriteLine("System.SByte");
                    break;
                case "System.Int16":
                    Console.WriteLine("System.Int16");
                    break;
                case "System.UInt16":
                    Console.WriteLine("System.UInt16");
                    break;
                case "System.Int64":
                    Console.WriteLine("System.Int64");
                    break;
                case "System.UInt64":
                    Console.WriteLine("System.UInt64");
                    break;
                case "System.Char":
                    Console.WriteLine("System.Char");
                    break;
                case "System.Double":
                    Console.WriteLine("System.Double");
                    break;
                case "System.Boolean":
                    Console.WriteLine("System.Boolean");
                    break;
                case "System.Single":
                    Console.WriteLine("System.Single");
                    break;
                default:
                    Console.WriteLine("Non system type");
                    break;
            }
        }

        void CompareUsingTypeofIfReturn(Type typea)
        {
            if (typea == typeof(int))
            {
                Console.WriteLine("System.Int32");
                return;
            }

            if (typea == typeof(uint))
            {
                Console.WriteLine("System.UInt32");
                return;
            }

            if (typea == typeof(byte))
            {
                Console.WriteLine("System.Byte");
                return;
            }

            if (typea == typeof(sbyte))
            {
                Console.WriteLine("System.SByte");
                return;
            }

            if (typea == typeof(short))
            {
                Console.WriteLine("System.Int16");
                return;
            }

            if (typea == typeof(ushort))
            {
                Console.WriteLine("System.UInt16");
                return;
            }

            if (typea == typeof(long))
            {
                Console.WriteLine("System.Int64");
                return;
            }

            if (typea == typeof(ulong))
            {
                Console.WriteLine("System.UInt64");
                return;
            }

            if (typea == typeof(char))
            {
                Console.WriteLine("System.Char");
                return;
            }

            if (typea == typeof(double))
            {
                Console.WriteLine("System.Double");
                return;
            }

            if (typea == typeof(bool))
            {
                Console.WriteLine("System.Boolean");
                return;
            }

            if (typea == typeof(float))
            {
                Console.WriteLine("System.Single");
                return;
            }

            Console.WriteLine("Non system type");
        }

        void CompareUsingTypeofIf(Type typea)
        {
            if (typea == typeof(int))
            {
                Console.WriteLine("System.Int32");
            }
            else if (typea == typeof(uint))
            {
                Console.WriteLine("System.UInt32");
            }
            else if (typea == typeof(byte))
            {
                Console.WriteLine("System.Byte");
            }
            else if (typea == typeof(sbyte))
            {
                Console.WriteLine("System.SByte");
            }
            else if (typea == typeof(short))
            {
                Console.WriteLine("System.Int16");
            }
            else if (typea == typeof(ushort))
            {
                Console.WriteLine("System.UInt16");
            }
            else if (typea == typeof(long))
            {
                Console.WriteLine("System.Int64");
            }
            else if (typea == typeof(ulong))
            {
                Console.WriteLine("System.UInt64");
            }
            else if (typea == typeof(char))
            {
                Console.WriteLine("System.Char");
            }
            else if (typea == typeof(double))
            {
                Console.WriteLine("System.Double");
            }
            else if (typea == typeof(bool))
            {
                Console.WriteLine("System.Boolean");
            }
            else if (typea == typeof(float))
            {
                Console.WriteLine("System.Single");
            }
            else
            {
                Console.WriteLine("Non system type");
            }
        }
    }
}