using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Day9_SmokeBasin
{
    public static class Helper
    {
        public static List<List<int>> Parse(List<string> entries)
        {
            var heights = new List<List<int>>();
            foreach (var entry in entries)
            {
                heights.Add(GetListInt(entry));
            }
            return heights;
        }
        public static int Part1(List<List<int>> heights)
        {
            var s = 0;
            for(var i = 0; i < heights.Count; i++)
            {
                for(var j = 0; j < heights[i].Count; j++)
                {
                    var expectedLows = GetExpectedLows(i, j, heights);
                    var lows = 0;
                    if (i - 1 >= 0 && heights[i - 1][j] > heights[i][j])
                    {
                        lows++;
                    }
                    if(j-1 >= 0 && heights[i][j-1] > heights[i][j])
                    {
                        lows++;
                    }
                    if(j+1 < heights[i].Count && heights[i][j+1] > heights[i][j])
                    {
                        lows++;
                    }
                    if(i+1 <heights.Count && heights[i+1][j] > heights[i][j])
                    {
                        lows++;
                    }
                    if(lows == expectedLows)
                    {
                        s += heights[i][j] + 1;
                    }
                }
            }
            return s;
        }
        public static int Part2(List<List<int>> heights)
        {
            var lowCoordinates = GetLowsCoordinates(heights);
            var visited = Helpers.InitializeIntArray(heights.Count, heights[0].Count);
            var stack = new Stack<(int, int)>();
            var sizes = new List<int>();
            foreach(var coordinate in lowCoordinates)
            {
                var count = 0;
                stack.Push((coordinate.Item1, coordinate.Item2));
                while(stack.Count > 0)
                {
                    var (row, col) = stack.Pop();
                    // Right: i, j++
                    for (var j = col + 1; j < heights[0].Count && heights[row][j] != 9; j++)
                    {
                        if (visited[row][j] != 1)
                        {
                            visited[row][j] = 1;
                            stack.Push((row, j));
                            count++;
                        }
                    }
                    // Left: i, j--
                    for (var j = col - 1; j >= 0 && heights[row][j] != 9; j--)
                    {
                        if (visited[row][j] != 1)
                        {
                            visited[row][j] = 1;
                            stack.Push((row, j));
                            count++;
                        }
                    }
                    // Up: i--, j
                    for (var i = row - 1; i >= 0 && heights[i][col] != 9; i--)
                    {
                        if (visited[i][col] != 1)
                        {
                            visited[i][col] = 1;
                            stack.Push((i, col));
                            count++;
                        }
                    }
                    // Down: i++, j
                    for (var i = row + 1; i < heights.Count && heights[i][col] != 9; i++)
                    {
                        if (visited[i][col] != 1)
                        {
                            visited[i][col] = 1;
                            stack.Push((i, col));
                            count++;
                        }
                    }
                }
                sizes.Add(count);
            }
            var descending = sizes.OrderByDescending(i => i).ToList();
            return descending[0] * descending[1] * descending[2];
        }
        private static List<int> GetListInt(string entry)
        {
            var heights = new List<int>();
            foreach(var ch in entry)
            {
                heights.Add(ch - '0');
            }
            return heights;
        }
        private static int GetExpectedLows(int i, int j, List<List<int>> heights)
        {
            if((i == 0 && j == 0)
                || (i == 0 && j == heights[0].Count-1)
                || (i == heights.Count - 1 && j == 0)
                || (i == heights.Count - 1 && j == heights[0].Count-1))
            {
                return 2;
            }
            else if(i == 0 || i == heights.Count -1 || j == 0 || j == heights[0].Count-1)
            {
                return 3;
            }
            return 4;
        }
        private static List<(int, int)> GetLowsCoordinates(List<List<int>> heights)
        {
            var coordinates = new List<(int, int)>();
            for (var i = 0; i < heights.Count; i++)
            {
                for (var j = 0; j < heights[i].Count; j++)
                {
                    var expectedLows = GetExpectedLows(i, j, heights);
                    var lows = 0;
                    if (i - 1 >= 0 && heights[i - 1][j] > heights[i][j])
                    {
                        lows++;
                    }
                    if (j - 1 >= 0 && heights[i][j - 1] > heights[i][j])
                    {
                        lows++;
                    }
                    if (j + 1 < heights[i].Count && heights[i][j + 1] > heights[i][j])
                    {
                        lows++;
                    }
                    if (i + 1 < heights.Count && heights[i + 1][j] > heights[i][j])
                    {
                        lows++;
                    }
                    if (lows == expectedLows)
                    {
                        coordinates.Add((i, j));
                    }
                }
            }
            return coordinates;
        }
    }
}
