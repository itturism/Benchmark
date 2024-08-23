namespace Benchmarks.Collection
{
    using BenchmarkDotNet.Attributes;
    using Microsoft.VSDiagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [ShortRunJob]
    [MemoryDiagnoser]
    [CPUUsageDiagnoser]
    public class SortedListTest
    {
        [Benchmark]
        public void Add_SortedList_String_1M()
        {
            GenerateString(1_000_000);
        }
        [Benchmark]
        public void Add_SortedList_String_10()
        {
            GenerateString(10);
        }

        private static void GenerateString(int n)
        {
            var list = new SortedList<int, string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(i, i.ToString());
            }
        }
        [Benchmark]
        public void Add_SortedList_Int()
        {
            var list = new SortedList<int, int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i, i);
            }
        }
        [Benchmark]
        public void Add_SortedList_Class()
        {
            var list = new SortedList<int, TestDataClassAndStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i, new TestDataClassAndStruct()
                {
                    Propperty1 = string.Empty,
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
        [Benchmark]
        public void Add_SortedList_Struct()
        {
            var list = new SortedList<int, TestDataStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i, new TestDataStruct()
                {
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
    }
}
