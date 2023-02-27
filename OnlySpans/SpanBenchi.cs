using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlySpans
{
    [MemoryDiagnoser(false)]
    public class SpanBenchi
    {
        public static readonly string _dateAsText = "26 02 2023";

        [Benchmark]
        public (int day, int month, int year) DateWithString() 
        {
            var dayAsText = _dateAsText.Substring(0, 2);
            var monthAsText = _dateAsText.Substring(3, 2);
            var yearAsText = _dateAsText.Substring(6);

            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);

            return (day, month, year);
        }


        [Benchmark]
        public (int day, int month, int year) DateWithStringSpan()
        {
            ReadOnlySpan<char> dateSpan = _dateAsText;
            var dayAsText = dateSpan.Slice(0, 2);
            var monthAsText = dateSpan.Slice(3, 2);
            var yearAsText = dateSpan.Slice(6);

            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);

            return (day, month, year);
        }
    }
}
