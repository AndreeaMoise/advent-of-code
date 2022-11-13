using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_DumboOctopus
{
    public static class Helper
    {
        public static List<List<int>> Parse(List<string> entries)
        {
            var energies = new List<List<int>>();
            foreach(var entry in entries)
            {
                energies.Add(GetListInt(entry));
            }
            return energies;
        }
        public static int Part1(List<List<int>> entries)
        {
            var countFlashes = 0;
            for(var amount = 0; amount < 100; amount++)
            {
                var flashed = new List<(int, int)>();
                var stack = new Stack<(int, int)>();
                for (var i = 0; i < entries.Count; i++)
                {
                    for (var j = 0; j < entries[0].Count; j++)
                    {
                        if(!flashed.Contains((i,j)))
                        {
                            entries[i][j]++;
                            if (entries[i][j] > 9)
                            {
                                stack.Push((i, j));
                            }
                        }
                        
                        while (stack.Count != 0)
                        {
                            var (row, col) = stack.Pop();
                            entries[row][col] = 0;
                            flashed.Add((row, col));
                            if (row - 1 >= 0)
                            {
                                if (col - 1 >= 0 && !flashed.Contains((row - 1, col - 1)))
                                {
                                    entries[row - 1][col - 1]++;
                                    if (entries[row - 1][col - 1] > 9 && !stack.Contains((row-1, col - 1)))
                                    {
                                        stack.Push((row - 1, col - 1));
                                    }
                                }
                                if (col + 1 < entries[row].Count && !flashed.Contains((row - 1, col + 1)))
                                {
                                    entries[row - 1][col + 1]++;
                                    if (entries[row - 1][col + 1] > 9 && !stack.Contains((row-1, col + 1)))
                                    {
                                        stack.Push((row - 1, col + 1));
                                    }
                                }
                                if (!flashed.Contains((row - 1, col)))
                                {
                                    entries[row - 1][col]++;
                                    if (entries[row - 1][col] > 9 && !stack.Contains((row-1, col)))
                                    {
                                        stack.Push((row - 1, col));
                                    }
                                }
                            }
                            if (row + 1 < entries.Count)
                            {
                                if (col - 1 >= 0 && !flashed.Contains((row + 1, col - 1)))
                                {
                                    entries[row + 1][col - 1]++;
                                    if (entries[row + 1][col - 1] > 9 && !stack.Contains((row+1, col - 1)))
                                    {
                                        stack.Push((row + 1, col - 1));
                                    }
                                }
                                if (col + 1 < entries[row].Count && !flashed.Contains((row + 1, col + 1)))
                                {
                                    entries[row + 1][col + 1]++;
                                    if (entries[row + 1][col + 1] > 9 && !stack.Contains((row +1, col + 1)))
                                    {
                                        stack.Push((row + 1, col + 1));
                                    }
                                }
                                if(!flashed.Contains((row + 1, col)))
                                {
                                    entries[row + 1][col]++;
                                    if (entries[row + 1][col] > 9 && !stack.Contains((row+1, col)))
                                    {
                                        stack.Push((row + 1, col));
                                    }
                                }
                            }
                            if (col - 1 >= 0 && !flashed.Contains((row, col - 1)))
                            {
                                entries[row][col - 1]++;
                                if (entries[row][col - 1] > 9 && !stack.Contains((row, col - 1)))
                                {
                                    stack.Push((row, col - 1));
                                }
                            }
                            if (col + 1 < entries[row].Count && !flashed.Contains((row, col + 1)))
                            {
                                entries[row][col + 1]++;
                                if (entries[row][col + 1] > 9 && !stack.Contains((row, col + 1))) 
                                {
                                    stack.Push((row, col + 1));
                                }
                            }
                        }
                    }
                }
                countFlashes += flashed.Count;
            }
            return countFlashes;
        }

        public static int Part2(List<List<int>> entries)
        {
            var step = 0;
            var flashed = new List<(int, int)>();
            while (flashed.Count != entries.Count*entries[0].Count)
            {
                flashed = new List<(int, int)>();
                var stack = new Stack<(int, int)>();
                for (var i = 0; i < entries.Count; i++)
                {
                    for (var j = 0; j < entries[0].Count; j++)
                    {
                        if (!flashed.Contains((i, j)))
                        {
                            entries[i][j]++;
                            if (entries[i][j] > 9)
                            {
                                stack.Push((i, j));
                            }
                        }

                        while (stack.Count != 0)
                        {
                            var (row, col) = stack.Pop();
                            entries[row][col] = 0;
                            flashed.Add((row, col));
                            if (row - 1 >= 0)
                            {
                                if (col - 1 >= 0 && !flashed.Contains((row - 1, col - 1)))
                                {
                                    entries[row - 1][col - 1]++;
                                    if (entries[row - 1][col - 1] > 9 && !stack.Contains((row - 1, col - 1)))
                                    {
                                        stack.Push((row - 1, col - 1));
                                    }
                                }
                                if (col + 1 < entries[row].Count && !flashed.Contains((row - 1, col + 1)))
                                {
                                    entries[row - 1][col + 1]++;
                                    if (entries[row - 1][col + 1] > 9 && !stack.Contains((row - 1, col + 1)))
                                    {
                                        stack.Push((row - 1, col + 1));
                                    }
                                }
                                if (!flashed.Contains((row - 1, col)))
                                {
                                    entries[row - 1][col]++;
                                    if (entries[row - 1][col] > 9 && !stack.Contains((row - 1, col)))
                                    {
                                        stack.Push((row - 1, col));
                                    }
                                }
                            }
                            if (row + 1 < entries.Count)
                            {
                                if (col - 1 >= 0 && !flashed.Contains((row + 1, col - 1)))
                                {
                                    entries[row + 1][col - 1]++;
                                    if (entries[row + 1][col - 1] > 9 && !stack.Contains((row + 1, col - 1)))
                                    {
                                        stack.Push((row + 1, col - 1));
                                    }
                                }
                                if (col + 1 < entries[row].Count && !flashed.Contains((row + 1, col + 1)))
                                {
                                    entries[row + 1][col + 1]++;
                                    if (entries[row + 1][col + 1] > 9 && !stack.Contains((row + 1, col + 1)))
                                    {
                                        stack.Push((row + 1, col + 1));
                                    }
                                }
                                if (!flashed.Contains((row + 1, col)))
                                {
                                    entries[row + 1][col]++;
                                    if (entries[row + 1][col] > 9 && !stack.Contains((row + 1, col)))
                                    {
                                        stack.Push((row + 1, col));
                                    }
                                }
                            }
                            if (col - 1 >= 0 && !flashed.Contains((row, col - 1)))
                            {
                                entries[row][col - 1]++;
                                if (entries[row][col - 1] > 9 && !stack.Contains((row, col - 1)))
                                {
                                    stack.Push((row, col - 1));
                                }
                            }
                            if (col + 1 < entries[row].Count && !flashed.Contains((row, col + 1)))
                            {
                                entries[row][col + 1]++;
                                if (entries[row][col + 1] > 9 && !stack.Contains((row, col + 1)))
                                {
                                    stack.Push((row, col + 1));
                                }
                            }
                        }
                    }
                }
                step++;
            }
            return step;
        }

        private static List<int> GetListInt(string entry)
        {
            var ints = new List<int>();
            foreach (var ch in entry)
            {
                ints.Add(ch - '0');
            }
            return ints;
        }
    }
}
