using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Lanternfish
{
    public static class Helper
    {
        public static int Part1(List<int> entries)
        {
            var interval = 80;
            for(var i = 0; i < interval; i++)
            {
                var currentCount = entries.Count;
                for(var j = 0; j < currentCount; j++)
                {
                    if(entries[j] > 0)
                    {
                        entries[j]--;
                    }
                    else
                    {
                        entries[j] = 6;
                        entries.Add(8);
                    }
                }
                Trace.WriteLine($"After {i + 1} day: {String.Join("'", entries)}");
            }
            return entries.Count;
        }
        public static double Part2(List<int> entries)
        {
            var interval = 256;
            var fishdata = new double[9];

            foreach (var n in entries)
                fishdata[n]++;

            for (int n = 0; n < interval; n++)
            {
                var newfish = fishdata[0];
                fishdata[0] = fishdata[1];
                fishdata[1] = fishdata[2];
                fishdata[2] = fishdata[3];
                fishdata[3] = fishdata[4];
                fishdata[4] = fishdata[5];
                fishdata[5] = fishdata[6];
                fishdata[6] = fishdata[7];
                fishdata[7] = fishdata[8];
                fishdata[8] = newfish;
                fishdata[6] += newfish;
            }

            var total = 0.0;

            foreach (var n in fishdata)
                total += n;

            return total;
        }
    }
}
