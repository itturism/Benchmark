namespace Benchmarks.Collection
{
    using BenchmarkDotNet.Attributes;
    using Microsoft.VSDiagnostics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [ShortRunJob]
    [MemoryDiagnoser]
    [CPUUsageDiagnoser]
    public class HashSetTest
    {
        [Benchmark]
        public void Add_HashSet_String_1M()
        {
            GenerateString(1_000_000);
        }
        [Benchmark]
        public void Add_HashSet_String_10()
        {
            GenerateString(10);
        }

        private static void GenerateString(int n)
        {
            var list = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(i.ToString());
            }
        }
        [Benchmark]
        public void Add_HashSet_Int()
        {
            var list = new HashSet<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i);
            }
        }
        [Benchmark]
        public void Add_HashSet_Class()
        {
            var list = new HashSet<TestDataClassAndStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new TestDataClassAndStruct()
                {
                    Propperty1 = string.Empty,
                    Propperty2 = i,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
        [Benchmark]
        public void Add_HashSet_Struct()
        {
            var list = new HashSet<TestDataStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new TestDataStruct()
                {
                    Propperty2 = i,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
    }
}
