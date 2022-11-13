using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_HydrothermalVenture
{
    public static class Helper
    {
        public static List<Line> Parse(List<string> entries)
        {
            var lines = new List<Line>();
            foreach (var entry in entries)
            {
                var numbers = entry.Split('-');
                var start = numbers[0].Split(',');
                var end = numbers[1].Substring(1).Split(',');
                var startPoint = new Point(Convert.ToInt32(start[1]), Convert.ToInt32(start[0]));
                var endPoint = new Point(Convert.ToInt32(end[1]), Convert.ToInt32(end[0]));
                lines.Add(new Line(startPoint, endPoint));
            }
            return lines;
        }

        public static int Part1(List<Line> lines)
        {
            var (maxX, maxY) = GetMaxCoordinates(lines);
            var grid = InitializeGrid(maxX, maxY);
            foreach (var line in lines)
            {
                if (line.Start.X == line.End.X)
                {
                    var lowerY = line.Start.Y <= line.End.Y ? line.Start.Y : line.End.Y;
                    var upperY = line.Start.Y > line.End.Y ? line.Start.Y : line.End.Y;
                    for(var i = lowerY; i <= upperY; i++)
                    {
                        grid[line.Start.X][i]++;
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    var lowerX = line.Start.X <= line.End.X ? line.Start.X : line.End.X;
                    var upperX = line.Start.X > line.End.X ? line.Start.X : line.End.X;
                    for(var i = lowerX; i <= upperX; i++)
                    {
                        grid[i][line.Start.Y]++;
                    }
                }
            }

            return GetOverlap(grid);
        }
        public static int Part2(List<Line> lines)
        {
            var (maxX, maxY) = GetMaxCoordinates(lines);
            var grid = InitializeGrid(maxX, maxY);
            foreach (var line in lines)
            {
                if (line.Start.X == line.End.X)
                {
                    var lowerY = line.Start.Y <= line.End.Y ? line.Start.Y : line.End.Y;
                    var upperY = line.Start.Y > line.End.Y ? line.Start.Y : line.End.Y;
                    for (var i = lowerY; i <= upperY; i++)
                    {
                        grid[line.Start.X][i]++;
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    var lowerX = line.Start.X <= line.End.X ? line.Start.X : line.End.X;
                    var upperX = line.Start.X > line.End.X ? line.Start.X : line.End.X;
                    for (var i = lowerX; i <= upperX; i++)
                    {
                        grid[i][line.Start.Y]++;
                    }
                }
                else
                {
                    if (line.Start.X > line.End.X)
                    {
                        var x = line.Start.X;
                        if (line.Start.Y <= line.End.Y)
                        {
                            for (var y = line.Start.Y; y <= line.End.Y; y++)
                            {
                                grid[x][y]++;
                                x--;
                            }
                        }
                        else
                        {
                            for (var y = line.Start.Y; y >= line.End.Y; y--)
                            {
                                grid[x][y]++;
                                x--;
                            }
                        }
                    }
                    else
                    {
                        var x = line.Start.X;
                        if(line.Start.Y <= line.End.Y)
                        {
                            for(var y = line.Start.Y; y <= line.End.Y; y++)
                            {
                                grid[x][y]++;
                                x++;
                            }
                        }
                        else
                        {
                            for (var y = line.Start.Y; y >= line.End.Y; y--)
                            {
                                grid[x][y]++;
                                x++;
                            }
                        }
                    }
                }
            }

            return GetOverlap(grid);
        }
        private static int GetOverlap(int[][] grid)
        {
            var overlap = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] >= 2)
                    {
                        overlap++;
                    }
                }
            }
            return overlap;
        }
        private static (int, int) GetMaxCoordinates(List<Line> lines)
        {
            var maxX = 0;
            var maxY = 0;
            foreach (var line in lines)
            {
                if (line.End.X > maxX)
                {
                    maxX = line.End.X;
                }
                if (line.Start.X > maxX)
                {
                    maxX = line.Start.X;
                }
                if(line.End.Y > maxY)
                {
                    maxY = line.End.Y;
                }
                if (line.Start.Y > maxY)
                {
                    maxY = line.Start.Y;
                }
            }
            return (maxX, maxY);
        }
        private static int[][] InitializeGrid(int maxX, int maxY)
        {
            var grid = new int[maxX+1][];
            for(var i = 0; i <= maxX; i++)
            {
                grid[i] = new int[maxY+1];
            }
            return grid;
        }
    }
}
