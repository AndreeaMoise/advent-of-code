using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_SonarSweep
{
    public static class Helper
    {
        public static int Part1(List<int> entries)
        {
            var current = entries[0];
            var counter = 0;
            for(var i = 1; i < entries.Count; i++)
            {
                if(entries[i] > current)
                {
                    counter++;
                }
                current = entries[i];
            }
            return counter;
        }
        public static int Part2(List<int> entries)
        {
            var first = entries[0];
            var second = entries[1];
            var windows = new List<int>();
            for(var i = 2; i < entries.Count; i++)
            {
                windows.Add(first + second + entries[i]);
                first = second;
                second = entries[i];
            }

            return Part1(windows);
        }
    }
}
