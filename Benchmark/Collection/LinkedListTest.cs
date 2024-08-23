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
    public class LinkedListTest
    {
        [Benchmark]
        public void Add_LinkedList_String_1M()
        {
            GenerateString(1_000_000);
        }
        [Benchmark]
        public void Add_LinkedList_String_10()
        {
            GenerateString(10);
        }

        private static void GenerateString(int n)
        {
            var list = new LinkedList<string>();
            for (int i = 0; i < n; i++)
            {
                list.AddLast(i.ToString());
            }
        }
        [Benchmark]
        public void Add_LinkedList_Int()
        {
            var list = new LinkedList<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.AddLast(i);
            }
        }
        [Benchmark]
        public void Add_LinkedList_Class()
        {
            var list = new LinkedList<TestDataClassAndStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.AddLast(new TestDataClassAndStruct()
                {
                    Propperty1 = string.Empty,
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
        [Benchmark]
        public void Add_LinkedList_Struct()
        {
            var list = new LinkedList<TestDataStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.AddLast(new TestDataStruct()
                {
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
    }
}
