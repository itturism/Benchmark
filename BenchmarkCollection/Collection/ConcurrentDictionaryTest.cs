namespace Benchmarks.Collection
{
    using BenchmarkDotNet.Attributes;
    using Microsoft.VSDiagnostics;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [ShortRunJob]
    [MemoryDiagnoser]
    [CPUUsageDiagnoser]
    public class ConcurrentDictionaryTest
    {
        [Benchmark]
        public void Add_ConcurrentDictionary_String_1M()
        {
            GenerateString(1_000_000);
        }
        [Benchmark]
        public void Add_ConcurrentDictionary_String_10()
        {
            GenerateString(10);
        }

        private static void GenerateString(int n)
        {
            var list = new ConcurrentDictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                list[i.ToString()] = i.ToString();
            }
        }
        [Benchmark]
        public void Add_ConcurrentDictionary_Int()
        {
            var list = new ConcurrentDictionary<int, int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list[i] = i;
            }
        }
        [Benchmark]
        public void Add_ConcurrentDictionary_Class()
        {
            var list = new ConcurrentDictionary<int, TestDataClassAndStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list[i] = new TestDataClassAndStruct()
                {
                    Propperty1 = string.Empty,
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                };
            }
        }
        [Benchmark]
        public void Add_ConcurrentDictionary_Struct()
        {
            var list = new ConcurrentDictionary<int, TestDataStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list[i] = new TestDataStruct()
                {
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                };
            }
        }
    }
}
