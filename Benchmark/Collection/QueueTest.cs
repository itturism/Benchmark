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
    public class QueueTest
    {
        [Benchmark]
        public void Add_Queue_String_1M()
        {
            GenerateString(1_000_000);
        }
        [Benchmark]
        public void Add_Queue_String_10()
        {
            GenerateString(10);
        }

        private static void GenerateString(int n)
        {
            var list = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                list.Enqueue(i.ToString());
            }
        }
        [Benchmark]
        public void Add_Queue_Int()
        {
            var list = new Queue<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Enqueue(i);
            }
        }
        [Benchmark]
        public void Add_Queue_Class()
        {
            var list = new Queue<TestDataClassAndStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Enqueue(new TestDataClassAndStruct()
                {
                    Propperty1 = string.Empty,
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
        [Benchmark]
        public void Add_Queue_Struct()
        {
            var list = new Queue<TestDataStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Enqueue(new TestDataStruct()
                {
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
    }
}
