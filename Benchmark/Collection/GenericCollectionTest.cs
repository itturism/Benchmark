namespace Benchmarks.Collection
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GenericCollectionTest<T, M> where T : ICollection<M>, new()
    {
        public void Add_String()
        {
            var list = new T();
            for (int i = 0; i < 1_000_000; i++)
            {
                //  list.Add(new M());
            }
        }
    }
}
