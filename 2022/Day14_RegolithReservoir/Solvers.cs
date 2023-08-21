using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_RegolithReservoir
{
    public static class Solvers
    {
        public static Tuple<List<Tuple<int, int>>, int> Parse(List<string> entries)
        {
            var xmin = 0;
            var xmax = 0;
            var ymin = 0;
            var ymax = 0;

            var separator = new string[] { " -> " };
            var rocks = new List<Tuple<int, int>>();

            var xprev = 0;
            var yprev = 0;
            for (var i = 0; i < entries.Count; i++)
            {
                var pathElements = entries[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                

                for (int j = 0; j < pathElements.Length; j++)
                {
                    var coordinates = pathElements[j].Split(',');

                    var x = Convert.ToInt32(coordinates[1]);
                    var y = Convert.ToInt32(coordinates[0]);

                    if (i == 0 && j == 0)
                    {
                        xmin = x;
                        xmax = x;
                        ymin = y;
                        ymax = y;
                    }
                    else
                    {
                        if (x < xmin)
                        {
                            xmin = x;
                        }
                        else if (x > xmax)
                        {
                            xmax = x;
                        }

                        if (y > ymax)
                        {
                            ymax = y;
                        }
                        else if (y < ymin)
                        {
                            ymin = y;
                        }
                    }

                    if (j == 0)
                    {
                        rocks.Add(new Tuple<int, int>(x, y));
                    }
                    else
                    {
                        if (xprev == x)
                        {
                            for (var k = Math.Min(y, yprev); k <= Math.Max(y, yprev); k++)
                            {
                                var t = new Tuple<int, int>(x, k);
                                if (!rocks.Contains(t))
                                {
                                    rocks.Add(t);
                                }
                            }
                        }
                        else if (yprev == y)
                        {
                            for (var k = Math.Min(x, xprev); k <= Math.Max(x, xprev); k++)
                            {
                                var t = new Tuple<int, int>(k, y);
                                if (!rocks.Contains(t))
                                {
                                    rocks.Add(t);
                                }
                            }
                        }
                    }
                    xprev = x;
                    yprev = y;
                    
                }
            }


            //var cave = Utils.Int2DArray.InitializeWith(xmax + 1, ymax - ymin + 1);
            //foreach (var coordinate in rocks)
            //{
            //    var (x, y) = coordinate;
            //    cave[x][y - ymin] = 1;
            //}

            //var p = cave[0].Length - ymax + 500 - 1;
            //cave[0][p] = 3;
            return new Tuple<List<Tuple<int, int>>, int>(rocks, xmax);
        }

        public static int Part1V2(List<Tuple<int, int>> rocks, int xmax)
        { 
            var ready = false;
            var units = 0;
            while (!ready)
            {
                var x = 0;
                var y = 500;

                var still = false;

                while (!still)
                {
                    if (x + 1 > xmax)
                    {
                        still = true;
                        ready = true;
                    }
                    // If straight down is air, move sand; rocks do not contain, it means air
                    if (!rocks.Contains(new Tuple<int, int>(x + 1, y)))
                    {
                        x = x + 1;
                    }
                    // If diagonal down left is air, move sand
                    else if (!rocks.Contains(new Tuple<int, int>(x + 1, y - 1)))
                    {
                        x = x + 1;
                        y = y - 1;
                    }
                    // If diagonal down right is air, move sand
                    else if (!rocks.Contains(new Tuple<int, int>(x + 1, y + 1)))
                    {
                        x = x + 1;
                        y = y + 1;
                    }
                    else
                    {
                        rocks.Add(new Tuple<int, int>(x, y));
                        still = true;
                        units++;
                    }
                }
            }

            return units;
        }

        public static int Part1(int[][] cave)
        {
            var xmax = cave.Length;
            var ymax = cave[0].Length;

            // Find source

            var sy = FindSource(cave[0]);

            var ready = false;
            var units = 0;
            while (!ready)
            {
                var x = 0;
                var y = sy;

                var still = false;
                
                while (!still)
                {
                    if (x + 1 >= xmax)
                    {
                        still = true;
                        ready = true;
                    }
                    // If straight down is air, move sand
                    else if (x + 1 < xmax && cave[x + 1][y] == 0)
                    {
                        x = x + 1;
                    }
                    // If diagonal down left is air, move sand
                    else if (x + 1 < xmax && y - 1 >= 0 && cave[x + 1][y - 1] == 0)
                    {
                        x = x + 1;
                        y = y - 1;
                    }
                    // If diagonal down right is air, move sand
                    else if (x + 1 < xmax && y + 1 < ymax && cave[x + 1][y + 1] == 0)
                    {
                        x = x + 1;
                        y = y + 1;
                    }
                    else
                    {
                        cave[x][y] = 2;
                        still = true;
                        units++;
                    }
                }
            }

            return units;
        }

        private static int FindSource(int[] x0)
        {
            for (var i = 0; i < x0.Length; i++)
            {
                if (x0[i] == 3)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
