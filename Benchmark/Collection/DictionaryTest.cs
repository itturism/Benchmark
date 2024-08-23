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
    public class DictionaryTest
    {
        [Benchmark]
        public void Add_Dictionary_String_1M()
        {
            GenerateString(1_000_000);
        }
        string A(string t)
        {
            return "";
        }

        [Benchmark]
        public void Add_Dictionary_String_10()
        {
            GenerateString(10);
        }

        private static void GenerateString(int n)
        {
            var list = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                list[i.ToString()] = i.ToString();
            }
        }
        [Benchmark]
        public void Add_Dictionary_Int()
        {
            var list = new Dictionary<int, int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                list[i] = i;
            }
        }
        [Benchmark]
        public void Add_Dictionary_Class()
        {
            var list = new Dictionary<int, TestDataClassAndStruct>();
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
        public void Add_Dictionary_Struct()
        {
            var list = new Dictionary<int, TestDataStruct>();
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
