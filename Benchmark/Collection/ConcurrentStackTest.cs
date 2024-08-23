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
    public class ConcurrentStackTest
    {
        [Benchmark]
        public void Push_ConcurrentStack_String()
        {
            var list = new ConcurrentStack<string>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Push(i.ToString());
            }
        }
        [Benchmark]
        public void Push_ConcurrentStack_Int()
        {
            var list = new ConcurrentStack<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Push(i);
            }
        }
        [Benchmark]
        public void Push_ConcurrentStack_Class()
        {
            var list = new ConcurrentStack<TestDataClassAndStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Push(new TestDataClassAndStruct()
                {
                    Propperty1 = string.Empty,
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
        [Benchmark]
        public void Push_ConcurrentStack_Struct()
        {
            var list = new ConcurrentStack<TestDataStruct>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Push(new TestDataStruct()
                {
                    Propperty2 = 0,
                    Propperty3 = 0,
                    Propperty4 = true,
                });
            }
        }
    }
}
