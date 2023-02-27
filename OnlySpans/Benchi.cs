using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace OnlySpans
{
    [MemoryDiagnoser(false)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class Benchi
    {

        private IEnumerable<int> _items;

        [GlobalSetup]
        public void Setup() 
        {
            _items = Enumerable.Range(1, 2000).ToArray();
        }


        [Benchmark]
        public double Avg() => _items.Average();

        [Benchmark]
        public int Sum() => _items.Sum();


        [Benchmark]
        public int Min() => _items.Min();

        [Benchmark]
        public int Max() => _items.Max();

        [Benchmark]
        public int Max_own() 
        {
            int biggest = int.MinValue;
            foreach (var item in _items)
            {
                if (item > biggest)
                    biggest = item;
            }
            return biggest;
        }


    }
}
