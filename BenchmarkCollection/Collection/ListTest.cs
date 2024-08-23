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
    public class ListTest
    {
        [Benchmark]
        public void Add_List_String_1M()
        {
            GenerateString(1_000_000, false);
        }
        [Benchmark]
        public void Add_List_String_10()
        {
            GenerateString(10, false);
        }
        [Benchmark]
        public void Add_List_String_With_Capcity_1M()
        {
            GenerateString(1_000_000, true);
        }
        [Benchmark]
        public void Add_List_String_With_Capcity_10()
        {
            GenerateString(10, true);
        }

        private static void GenerateString(int n, bool capcity)
        {
            var list = new List<string>(capcity ? n : 0);
            for (int i = 0; i < n; i++)
            {
                list.Add(i.ToString());
            }
        }

        [Benchmark]
        public void Add_List_Int()
        {
            var list = new List<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i);
            }
        }
        [Benchmark]
        public void Add_List_Class()
        {
            var list = new List<TestDataClassAndStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new TestDataClassAndStruct()
                {
                    Propperty1 = string.Empty,
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
        [Benchmark]
        public void Add_List_Struct()
        {
            var list = new List<TestDataStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new TestDataStruct()
                {
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
    }
}
