using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_TransparentOrigami
{
    public static class Helper
    {
        public static (List<List<int>>, List<(char, int)>) Parse(List<string> entries)
        {
            var dots = InitializeArray(entries);
            var folds = new List<(char, int)>();
            foreach(var entry in entries)
            {
                if (entry.Contains(","))
                {
                    var split = entry.Split(',');
                    dots[Convert.ToInt32(split[1])][Convert.ToInt32(split[0])] = 1;
                }
                else if(entry.Contains("fold"))
                {
                    var split = entry.Split('=');
                    folds.Add((split[0].Last(), Convert.ToInt32(split[1])));
                }
            }
            return (ConvertMultiArrayToList(dots), folds);
        }
        public static int Part1(List<List<int>> dots, List<(char, int)> folds)
        {
            var folded = Fold(dots, folds[0]);

            var dotsCount = 0;
            for(var i = 0; i < folded.Count; i++)
            {
                for(var j = 0; j < folded[0].Count; j++)
                {
                    if(folded[i][j] == 1)
                    {
                        dotsCount++;
                    }
                }
            }
            return dotsCount;
        }
        public static void Part2(List<List<int>> dots, List<(char, int)> folds)
        {
            foreach(var fold in folds)
            {
                dots = Fold(dots, fold);
            }
            foreach(var line in dots)
            {
                foreach(var c in line)
                {
                    if(c == 1)
                    {
                        Trace.Write("#");
                    }
                    else
                    {
                        Trace.Write(".");
                    }
                }
                Trace.WriteLine("");
            }
        }
        private static List<List<int>> Fold(List<List<int>> dots, (char, int) fold)
        {
            var i = fold.Item2 - 1;
            var j = fold.Item2 + 1;
            if (fold.Item1 == 'y')
            {
                return FoldOnY(dots, i, j);
            }
            return FoldOnX(dots, i, j);
        }
        private static int[][] InitializeArray(List<string> entries)
        {
            var maxX = 0;
            var maxY = 0;
            foreach(var entry in entries)
            {
                if (entry.Contains(","))
                {
                    var y = Convert.ToInt32(entry.Split(',')[0]);
                    var x = Convert.ToInt32(entry.Split(',')[1]);
                    if(x > maxX)
                    {
                        maxX = x;
                    }
                    if(y > maxY)
                    {
                        maxY = y;
                    }
                }
            }
            var result = new int[maxX+1][];
            for (var i = 0; i <= maxX; i++)
            {
                result[i] = new int[maxY + 1];
                for(var j = 0; j <= maxY; j++)
                {
                    result[i][j] = 0;
                }
            }
            return result;
        }
        private static List<List<int>> ConvertMultiArrayToList(int[][] multiArray)
        {
            var result = new List<List<int>>();
            foreach(var entry in multiArray)
            {
                result.Add(entry.ToList());
            }
            return result;
        }
        private static List<List<int>> FoldOnY(List<List<int>> dots, int i, int j)
        {
            var endRange = i + 1;
            while (i >= 0 && j < dots.Count)
            {
                for (var k = 0; k < dots[0].Count; k++)
                {
                    if (dots[i][k] == 1 || dots[j][k] == 1)
                    {
                        dots[i][k] = 1;
                    }
                }
                i--;
                j++;
            }
            return dots.GetRange(0, endRange);
        }
        private static List<List<int>> FoldOnX(List<List<int>> dots, int i, int j)
        {
            var endRange = i + 1;
            while (i >= 0 && j < dots[0].Count)
            {
                for (var k = 0; k < dots.Count; k++)
                {
                    if (dots[k][i] == 1 || dots[k][j] == 1)
                    {
                        dots[k][i] = 1;
                    }
                }
                i--;
                j++;
            }
            var temp = new List<List<int>>();
            foreach(var line in dots)
            {
                temp.Add(line.GetRange(0, endRange));
            }
            return temp;
        }
    }
}
