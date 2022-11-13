using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_Chiton
{
    public static class Helper
    {
        public static List<List<int>> Parse(List<string> entries)
        {
            var map = new List<List<int>>();
            foreach(var entry in entries)
            {
                var line = new List<int>();
                foreach(var ch in entry)
                {
                    line.Add(ch - '0');
                }
                map.Add(line);
            }
            return map;
        }

        public static int Part1(List<List<int>> map)
        {
            var result =  MinCost(map, map.Count, map[0].Count);
            //foreach(var line in costs)
            //{
            //    foreach(var cost in line)
            //    {
            //        Trace.Write(cost + " ");
            //    }
            //    Trace.WriteLine("");
            //}

            var output = new List<(int, int)>();
            var p = map.Count-1;
            var q = map[0].Count-1;
            var a = 0;
            var b = 0;
            while (p != a && q != b)
            {
                output.Add((p, q));
                var min = int.MaxValue;
                var newP = -1;
                var newQ = -1;
                if (p - 1 >= 0 && tc[p - 1][q] < min)
                {
                    min = tc[p - 1][q];
                    newP = p - 1;
                    newQ = q;
                }


                if (q - 1 >= 0 && tc[p][q - 1] < min)
                {
                    min = tc[p][q - 1];
                    newP = p;
                    newQ = q - 1;
                }


                p = newP;
                q = newQ;
            }

            output.Add((a, b));

            var cost = 0;
            foreach (var el in output)
            {
                Trace.Write(el);
                cost += map[el.Item1][el.Item2];
            }
            
            //if(output.Contains((0,0)))
            //{
            //    return result - map[0][0];
            //}
            return result;
        }
        //private static int[][] tc;
        public static int MinCost(List<List<int>> map, int m, int n)
        {
            var tc = new int[map.Count, map[0].Count];

            // Initialize
            for (var i = 0; i < map.Count; i++)
            {
                for(var j = 0; j < map[0].Count; j++)
                {
                    tc[i, j] = int.MaxValue;
                }
            }

            tc[0, 0] = 0;
            //tc = new int[map.Count][];

            //for (var k = 0; k < map.Count; k++)
            //{
            //    tc[k] = new int[map[0].Count];
            //}

            //// Do not count the left top corner unless it is entered.
            //tc[0][0] = 0;

            ///* Initialize first row of tc array */
            //for (j = 1; j < n; j++)
            //{
            //    tc[0][j] = tc[0][j - 1] + map[0][j];
            //}

            ///* Initialize first column of total cost(tc) array */
            //for (i = 1; i < m; i++)
            //{
            //    tc[i][0] = tc[i - 1][0] + map[i][0];
            //}


            ///* Construct rest of the tc array */
            //for (i = 1; i < m; i++)
            //    for (j = 1; j < n; j++)
            //    {
            //        tc[i][j] = map[i][j] + Math.Min(tc[i - 1][j], tc[i][j - 1]);
            //    }
            //return tc[m-1][n-1];
        }
        private static int Min(int a, int b, int c, int d)
        {
            var list = new List<int>() { a, b, c, d }.Where(el => el != 0).ToList();
            list.Sort();
            return list[0];
        }
    }
}
