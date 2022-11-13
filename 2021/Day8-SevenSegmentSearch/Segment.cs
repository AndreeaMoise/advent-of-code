using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_SevenSegmentSearch
{
    public class Segment
    {
        public List<string> Input { get; }
        public List<string> Output { get; }
        public Segment(List<string> input, List<string> output)
        {
            Input = input;
            Output = output;
        }
    }
}
