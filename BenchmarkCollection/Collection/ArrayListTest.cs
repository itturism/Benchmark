namespace Benchmarks.Collection
{
    using BenchmarkDotNet.Attributes;
    using Microsoft.VSDiagnostics;
    using System.Collections;

    [ShortRunJob]
    [MemoryDiagnoser]
    [CPUUsageDiagnoser]
    public class ArrayListTest
    {
        [Benchmark]
        public void Add_ArrayList_String()
        {
            var list = new ArrayList();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i.ToString());
            }
        }
        [Benchmark]
        public void Add_ArrayList_Int()
        {
            var list = new ArrayList();
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(i);
            }
        }
        [Benchmark]
        public void Add_ArrayList_Class()
        {
            var list = new ArrayList();
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
        public void Add_ArrayList_Struct()
        {
            var list = new ArrayList();
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
