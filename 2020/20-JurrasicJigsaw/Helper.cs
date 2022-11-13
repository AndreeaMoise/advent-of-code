using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20_JurrasicJigsaw
{
    public static class Helper
    {
        public static Dictionary<string, Tile> Parse(List<string> entries)
        {
            var id = "";
            var lines = new List<string>();
            var dictionary = new Dictionary<string, Tile>();
            foreach (var entry in entries)
            {
                if (entry.Contains("Tile"))
                {
                    if (id != "")
                    {
                        dictionary.Add(id, new Tile(id, GetTopEdge(lines), GetRightEdge(lines), GetLeftEdge(lines), GetBottomEdge(lines)));
                    }
                    id = entry.Substring(5, entry.Length - 6);
                    lines = new List<string>();
                }
                else if (entry != "")
                {
                    lines.Add(entry);
                }
            }
            dictionary.Add(id, new Tile(id, GetTopEdge(lines), GetRightEdge(lines), GetLeftEdge(lines), GetBottomEdge(lines)));
            return dictionary;
        }

        public static long Part1(Dictionary<string, Tile> dictionary)
        {
            long result = 1;

            for (var i = 0; i < dictionary.Count; i++)
            {
                var baseTile = dictionary.ElementAt(i).Value;
                for (var j = 0; j < dictionary.Count; j++)
                {
                    var currentTile = dictionary.ElementAt(j).Value;
                    if (baseTile.Id != currentTile.Id)
                    {
                        baseTile.HasTopEdgeMatch = baseTile.HasTopEdgeMatch || IsEdgeMatching(baseTile.TopEdge, currentTile);
                        baseTile.HasBottomEdgeMatch = baseTile.HasBottomEdgeMatch || IsEdgeMatching(baseTile.BottomEdge, currentTile);
                        baseTile.HasLeftEdgeMatch = baseTile.HasLeftEdgeMatch || IsEdgeMatching(baseTile.LeftEdge, currentTile);
                        baseTile.HasRightEdgeMatch = baseTile.HasRightEdgeMatch || IsEdgeMatching(baseTile.RightEdge, currentTile);
                    }
                }
                var shortEgde = (baseTile.HasTopEdgeMatch && !baseTile.HasBottomEdgeMatch) || (!baseTile.HasTopEdgeMatch && baseTile.HasBottomEdgeMatch);
                var longEdge = (baseTile.HasRightEdgeMatch && !baseTile.HasLeftEdgeMatch) || (!baseTile.HasRightEdgeMatch && baseTile.HasLeftEdgeMatch);
                if (shortEgde && longEdge)
                {
                    result *= Convert.ToInt32(baseTile.Id);
                }
            }
            return result;
        }

        public static bool IsEdgeMatching(string edge, Tile currentTile)
        {
            return edge == currentTile.TopEdge
                || edge == currentTile.LeftEdge
                || edge == currentTile.BottomEdge
                || edge == currentTile.RightEdge
                || Utils.StringHelper.Reverse(edge) == currentTile.TopEdge
                || Utils.StringHelper.Reverse(edge) == currentTile.LeftEdge
                || Utils.StringHelper.Reverse(edge) == currentTile.BottomEdge
                || Utils.StringHelper.Reverse(edge) == currentTile.RightEdge;
        }

        public static long Part2(Dictionary<string, Tile> dictionary)
        {
            long result = 1;
            for (var i = 0; i < dictionary.Count - 1; i++)
            {
                var baseTile = dictionary.ElementAt(i).Value;
                for (var j = i + 1; j < dictionary.Count; j++)
                {
                    var currentTile = dictionary.ElementAt(j).Value;

                    if (baseTile.TopEdge == currentTile.LeftEdge)
                    {
                        // Rotate base tile 270
                        baseTile.RightEdgeMatch = currentTile.Id;
                        currentTile.LeftEdgeMatch = baseTile.Id;
                        baseTile.HasRightEdgeMatch = true;
                    }
                    else if (baseTile.TopEdge == currentTile.BottomEdge)
                    {
                        baseTile.TopEdgeMatch = currentTile.Id;
                        currentTile.BottomEdgeMatch = baseTile.Id;
                        baseTile.HasTopEdgeMatch = true;
                    }
                    else if (Utils.StringHelper.Reverse(baseTile.TopEdge) == currentTile.RightEdge)
                    {
                        // Flip base tile and rotate 90
                        baseTile.LeftEdgeMatch = currentTile.Id;
                        currentTile.RightEdgeMatch = baseTile.Id;
                        baseTile.HasLeftEdgeMatch = true;
                    }
                    else if (baseTile.BottomEdge == currentTile.TopEdge)
                    {
                        baseTile.BottomEdgeMatch = currentTile.Id;
                        currentTile.TopEdgeMatch = baseTile.Id;
                        baseTile.HasBottomEdgeMatch = true;
                    }
                    else if (baseTile.BottomEdge == currentTile.RightEdge)
                    {
                        // Rotate base tile 270
                        baseTile.LeftEdgeMatch = currentTile.Id;
                        currentTile.RightEdgeMatch = baseTile.Id;
                        baseTile.HasLeftEdgeMatch = true;
                    }
                    else if (Utils.StringHelper.Reverse(baseTile.BottomEdge) == currentTile.LeftEdge)
                    {
                        // Flip and 90
                        baseTile.RightEdgeMatch = currentTile.Id;
                        currentTile.LeftEdgeMatch = baseTile.Id;
                        baseTile.HasRightEdgeMatch = true;
                    }

                    var shortEgde = (baseTile.HasTopEdgeMatch && !baseTile.HasBottomEdgeMatch) || (!baseTile.HasTopEdgeMatch && baseTile.HasBottomEdgeMatch);
                    var longEdge = (baseTile.HasRightEdgeMatch && !baseTile.HasLeftEdgeMatch) || (!baseTile.HasRightEdgeMatch && baseTile.HasLeftEdgeMatch);
                    if (shortEgde && longEdge)
                    {
                        result *= Convert.ToInt32(baseTile.Id);
                    }
                }
            }
            return result;
        }

        //private static Tuple<Tile, Tile> MatchTopEdge(Tile baseTile, Tile currentTile)
        //{
        //    if (baseTile.TopEdge == )
        //    {
        //        // Flip currentTile
        //        baseTile.TopEdgeMatch = currentTile.Id;
        //        currentTile.BottomEdgeMatch = baseTile.Id;
        //    }
        //    else if (baseTile.TopEdge == currentTile.BottomEdge)
        //    {
        //        baseTile.TopEdgeMatch = currentTile.Id;
        //        currentTile.BottomEdgeMatch = baseTile.Id;
        //    }
        //    else if (baseTile.BottomEdge == currentTile.BottomEdge)
        //    {

        //    }

        //    return new Tuple<Tile, Tile> { item1: baseTile, currentTile };
        //}
        public static bool IsTopEdgeMatching(Tile baseTile, Tile currentTile)
        {
            return baseTile.TopEdge == Utils.StringHelper.Reverse(currentTile.TopEdge)
                || baseTile.TopEdge == currentTile.BottomEdge
                || baseTile.TopEdge == Utils.StringHelper.Reverse(currentTile.BottomEdge)
                || baseTile.TopEdge == currentTile.RightEdge
                || baseTile.TopEdge == Utils.StringHelper.Reverse(currentTile.RightEdge)
                || baseTile.TopEdge == currentTile.LeftEdge
                || baseTile.TopEdge == Utils.StringHelper.Reverse(currentTile.LeftEdge);
        }

        public static bool IsBottomEdgeMatching(Tile baseTile, Tile currentTile)
        {
            return baseTile.BottomEdge == currentTile.TopEdge
                || baseTile.BottomEdge == Utils.StringHelper.Reverse(currentTile.TopEdge)
                || baseTile.BottomEdge == Utils.StringHelper.Reverse(currentTile.BottomEdge)
                || baseTile.BottomEdge == currentTile.RightEdge
                || baseTile.BottomEdge == Utils.StringHelper.Reverse(currentTile.RightEdge)
                || baseTile.BottomEdge == currentTile.LeftEdge
                || baseTile.BottomEdge == Utils.StringHelper.Reverse(currentTile.LeftEdge);
        }

        public static bool IsRightEdgeMatching(Tile baseTile, Tile currentTile)
        {
            return baseTile.RightEdge == currentTile.TopEdge
               || baseTile.RightEdge == Utils.StringHelper.Reverse(currentTile.TopEdge)
               || baseTile.RightEdge == currentTile.BottomEdge
               || baseTile.RightEdge == Utils.StringHelper.Reverse(currentTile.BottomEdge)
               || baseTile.RightEdge == Utils.StringHelper.Reverse(currentTile.RightEdge)
               || baseTile.RightEdge == currentTile.LeftEdge
               || baseTile.RightEdge == Utils.StringHelper.Reverse(currentTile.LeftEdge);
        }

        public static bool IsLeftEdgeMatching(Tile baseTile, Tile currentTile)
        {
            return baseTile.LeftEdge == currentTile.TopEdge
              || baseTile.LeftEdge == Utils.StringHelper.Reverse(currentTile.TopEdge)
              || baseTile.LeftEdge == currentTile.BottomEdge
              || baseTile.LeftEdge == Utils.StringHelper.Reverse(currentTile.BottomEdge)
              || baseTile.LeftEdge == currentTile.RightEdge
              || baseTile.LeftEdge == Utils.StringHelper.Reverse(currentTile.RightEdge)
              || baseTile.LeftEdge == Utils.StringHelper.Reverse(currentTile.LeftEdge);
        }

        private static string GetTopEdge(List<string> lines)
        {
            return lines[0];
        }
        private static string GetBottomEdge(List<string> lines)
        {
            return lines[lines.Count-1];
        } 
        private static string GetLeftEdge(List<string> lines)
        {
            var leftEdge = "";
            for(var i = 0; i < lines.Count; i++)
            {
                leftEdge += lines[i][0];
            }
            return leftEdge;
        }
        private static string GetRightEdge(List<string> lines)
        {
            var length = lines[0].Length;
            var rightEdge = "";
            for (var i = 0; i < lines.Count; i++)
            {
                rightEdge += lines[i][length - 1];
            }
            return rightEdge;
        }
    }
}
