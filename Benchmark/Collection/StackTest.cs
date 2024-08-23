namespace Benchmarks.Collection
{
    using BenchmarkDotNet.Attributes;
    using Microsoft.VSDiagnostics;
    using System.Collections.Generic;

    [ShortRunJob]
    [MemoryDiagnoser]
    [CPUUsageDiagnoser]
    public class StackTest
    {
        [Benchmark]
        public void Push_Stack_String()
        {
            var list = new Stack<string>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Push(i.ToString());
            }
        }
        [Benchmark]
        public void Push_Stack_Int()
        {
            var list = new Stack<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Push(i);
            }
        }
        [Benchmark]
        public void Push_Stack_Class()
        {
            var list = new Stack<TestDataClassAndStruct>();
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
        public void Push_Stack_Struct()
        {
            var list = new Stack<TestDataStruct>();
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
