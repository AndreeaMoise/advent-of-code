using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Helpers
    {
        public static int[][] InitializeIntArray(int rows, int cols)
        {
            var array = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                array[i] = new int[cols];
            }
            return array;
        }

        public static List<string> DeepCloneListString(List<string> original)
        {
            var clone = new List<string>();
            foreach(var entry in original)
            {
                var line = "";
                foreach(var ch in entry)
                {
                    line += ch;
                }
                clone.Add(line);
            }
            return clone;
        }
    }
}
