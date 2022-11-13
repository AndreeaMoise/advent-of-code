using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_TheTreacheryOfWhales
{
    public static class Helper
    {
        public static int Part1(List<int> entries)
        {
            var max = GetMax(entries);
            var min = int.MaxValue;
            for(var i = 0; i < max; i++)
            {
                var fuel = GetFuelAtPosition(i, entries);
                if(fuel < min)
                {
                    min = fuel;
                }
            }
            return min;
        }
        public static int Part2(List<int> entries)
        {
            var max = GetMax(entries);
            var min = int.MaxValue;
            for (var i = 0; i < max; i++)
            {
                var fuel = GetFuelAtPositionForPart2(i, entries);
                if (fuel < min)
                {
                    min = fuel;
                }
            }
            return min;
        }
        private static int GetFuelAtPosition(int x, List<int> entries)
        {
            var s = 0;
            foreach(var entry in entries)
            {
                s += Math.Abs(entry - x);
            }
            return s;
        }
        private static int GetFuelAtPositionForPart2(int x, List<int> entries)
        {
            var s = 0;
            foreach (var entry in entries)
            {
                var distance = Math.Abs(entry - x);
                s += (distance * (distance + 1) / 2);
            }
            return s;
        }
        private static int GetMax(List<int> entries)
        {
            var max = 0;
            for(var i = 0; i < entries.Count; i++)
            {
                if(entries[i] > max)
                {
                    max = entries[i];
                }
            }
            return max;
        }
    }
}
