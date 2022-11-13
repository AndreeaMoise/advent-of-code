using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_BinaryDiagnostic
{
    public static class Helper
    {
        public static List<List<int>> Parse(List<string> entries)
        {
            var result = new List<List<int>>();
            foreach(var entry in entries)
            {
                var bits = new List<int>();
                foreach(var ch in entry)
                {
                    bits.Add(ch-'0');
                }
                result.Add(bits);
            }
            return result;
        }

        public static double Part1(List<List<int>> entries)
        {
            var gamma = new List<int>(); //most common
            var epsilon = new List<int>();
            for(var j = 0; j < entries[0].Count; j++)
            {
                var count0 = 0;
                var count1 = 0;
                for (var i = 0; i < entries.Count; i++)
                {
                    if (entries[i][j] == 0)
                    {
                        count0++;
                    }
                    else
                    {
                        count1++;
                    }
                }
                if(count1 >= count0)
                {
                    gamma.Add(1);
                    epsilon.Add(0);
                }
                else
                {
                    gamma.Add(0);
                    epsilon.Add(1);
                }
            }
            return BinaryToDecimal(gamma) * BinaryToDecimal(epsilon);
        }

        public static double Part2(List<List<int>> entries)
        {
            return BinaryToDecimal(GetOxygen(entries)) * BinaryToDecimal(GetScrubber(entries));
        }

        private static double BinaryToDecimal(List<int> bits)
        {
            var result = 0.0;
            bits.Reverse();
            for(var i = 0; i < bits.Count; i++)
            {
                if(bits[i] == 1)
                {
                    result += Math.Pow(2, i);
                }
            }
            return result;
        }

        private static List<int> GetOxygen(List<List<int>> entries)
        {
            var oxygen = entries; //most common
            for (var j = 0; j < entries[0].Count && oxygen.Count > 1; j++)
            {
                var count0 = 0;
                var count1 = 0;
                for (var i = 0; i < oxygen.Count; i++)
                {
                    if (oxygen[i][j] == 0)
                    {
                        count0++;
                    }
                    else
                    {
                        count1++;
                    }
                }

                var value = count1 >= count0 ? 1 : 0; // to keep
                var temp = new List<List<int>>(oxygen);
                foreach (var entry in oxygen)
                {
                    if (entry[j] != value)
                    {
                        temp.Remove(entry);
                    }
                }
                oxygen = temp;
            }
            return oxygen[0];
        }

        private static List<int> GetScrubber(List<List<int>> entries)
        {
            var scrubber = entries; //most common
            for (var j = 0; j < entries[0].Count && scrubber.Count > 1; j++)
            {
                var count0 = 0;
                var count1 = 0;
                for (var i = 0; i < scrubber.Count; i++)
                {
                    if (scrubber[i][j] == 0)
                    {
                        count0++;
                    }
                    else
                    {
                        count1++;
                    }
                }

                var value = count1 >= count0 ? 0 : 1; // to keep
                var temp = new List<List<int>>(scrubber);
                foreach (var entry in scrubber)
                {
                    if (entry[j] != value)
                    {
                        temp.Remove(entry);
                    }
                }
                scrubber = temp;
            }
            return scrubber[0];
        }
    }
}
