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
    public class ConcurrentBagTest
    {
        [Benchmark]
        public void Add_ConcurrentBag_String()
        {
            var list = new ConcurrentBag<string>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i.ToString());
            }
        }
        [Benchmark]
        public void Add_ConcurrentBag_Int()
        {
            var list = new ConcurrentBag<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i);
            }
        }
        [Benchmark]
        public void Add_ConcurrentBag_Class()
        {
            var list = new ConcurrentBag<TestDataClassAndStruct>();
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
        public void Add_ConcurrentBag_Struct()
        {
            var list = new ConcurrentBag<TestDataStruct>();
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
