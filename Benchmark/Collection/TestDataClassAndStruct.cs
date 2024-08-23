namespace Benchmarks.Collection
{
    public class TestDataClassAndStruct
    {
        public string Propperty1 { get; set; }
        public int Propperty2 { get; set; }
        public double Propperty3 { get; set; }
        public bool Propperty4 { get; set; }

        public override int GetHashCode()
        {
            return Propperty2;
        }
    }
    public struct TestDataStruct
    {
        public int Propperty2 { get; set; }
        public double Propperty3 { get; set; }
        public bool Propperty4 { get; set; }

        public override int GetHashCode()
        {
            return Propperty2;
        }
    }
}
