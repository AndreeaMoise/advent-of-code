using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_ReactorReboot
{
    public static class Helper
    {
        public static int Part1(List<string> entries)
        {
            var ons = new int[101, 101, 101];
            foreach(var entry in entries)
            {
                var split = entry.Split(' ');

                var coordinatesSplit = split[1].Split(',');
                var xBound = coordinatesSplit[0].Split('=')[1].Split(new string[] { ".." }, StringSplitOptions.None);
                var yBound = coordinatesSplit[1].Split('=')[1].Split(new string[] { ".." }, StringSplitOptions.None);
                var zBound = coordinatesSplit[2].Split('=')[1].Split(new string[] { ".." }, StringSplitOptions.None);
                for(var x = Convert.ToInt32(xBound[0]) + 50; x <= Convert.ToInt32(xBound[1]) + 50; x++)
                {
                    for (var y = Convert.ToInt32(yBound[0]) + 50; y <= Convert.ToInt32(yBound[1]) + 50; y++)
                    {
                        for (var z = Convert.ToInt32(zBound[0]) + 50; z <= Convert.ToInt32(zBound[1]) + 50; z++)
                        {
                            ons[x, y, z] = split[0] == "on" ? 1 : 0;
                        }
                    }
                }
            }
            return GetOns(ons);
        }
        private static int GetOns(int[,,] ons)
        {
            var counter = 0;
            foreach(var i in ons)
            {
                if(i == 1)
                {
                    counter++;
                }
            }
            return counter;
        }
        //private static ((long, long), (long, long), (long, long))? Overlap(((long, long), (long, long), (long, long)) cube1, ((long, long), (long, long), (long, long)) cube2)
        //{
        //    var overlapX = Overlap(cube1.Item1, cube2.Item1);
        //    if (overlapX == null)
        //        return null;

        //    var overlapY= Overlap(cube1.Item2, cube2.Item2);
        //    if (overlapY == null)
        //        return null;

        //    var overlapZ = Overlap(cube1.Item3, cube2.Item3);
        //    if (overlapZ == null)
        //        return null;

        //    return (((long, long), (long, long), (long, long)))(overlapX, overlapY, overlapZ);
        //}
        //private static (long, long)? Overlap((long, long) bounds1, (long, long) bounds2)
        //{
        //    if (bounds1.Item2 < bounds2.Item1 && bounds2.Item2 < bounds1.Item1)
        //        return null;

        //    return (Math.Max(bounds1.Item1, bounds2.Item1), Math.Min(bounds1.Item2, bounds2.Item2));
        //}
        
        public static List<(Cuboid, bool)> Parse2(List<string> entries)
        {
            var cuboids = new List<(Cuboid, bool)>();
            foreach (var entry in entries)
            {
                var split = entry.Split(' ');

                var coordinatesSplit = split[1].Split(',');
                var xBound = coordinatesSplit[0].Split('=')[1].Split(new string[] { ".." }, StringSplitOptions.None);
                var yBound = coordinatesSplit[1].Split('=')[1].Split(new string[] { ".." }, StringSplitOptions.None);
                var zBound = coordinatesSplit[2].Split('=')[1].Split(new string[] { ".." }, StringSplitOptions.None);
                var command = split[0] == "on";
                cuboids.Add((new Cuboid(
                    Convert.ToInt32(xBound[0]), Convert.ToInt32(xBound[1]),
                    Convert.ToInt32(yBound[0]), Convert.ToInt32(yBound[1]),
                    Convert.ToInt32(zBound[0]), Convert.ToInt32(zBound[1])),
                    command));
            }
            return cuboids;
        }

        public static long Part2(List<(Cuboid, bool)> commands)
        {
            var positives = new List<Cuboid>();
            var negatives = new List<Cuboid>();
            foreach(var command in commands)
            {
                var posIntersections = FindIntersections(command.Item1, positives);
                var negIntersections = FindIntersections(command.Item1, negatives);

                positives.AddRange(negIntersections);
                negatives.AddRange(posIntersections);

                if(command.Item2)
                {
                    positives.Add(command.Item1);
                }
            }
            return GetTotalVolume(positives) - GetTotalVolume(negatives);
        }

        private static List<Cuboid> FindIntersections(Cuboid cuboid,List<Cuboid> cuboids)
        {
            var intersection = new List<Cuboid>();
            foreach(var aux in cuboids)
            {
                if(cuboid.Overlaps(aux))
                {
                    intersection.Add(cuboid.Intersection(aux));
                }
            }
            return intersection;
        }

        private static long Volume(((long, long), (long, long), (long, long)) cube)
        {
            return Size(cube.Item1) * Size(cube.Item2) * Size(cube.Item3);
        }

        private static long Size((long, long) bounds)
        {
            if(bounds.Item2 >= bounds.Item1)
            {
                return Math.Abs(bounds.Item2 - bounds.Item1) + 1;
            }
            return 1;
        }
        private static Dictionary<((long, long), (long, long), (long, long)), bool> MergeDict(Dictionary<((long, long), (long, long), (long, long)), bool> original, Dictionary<((long, long), (long, long), (long, long)), bool> incoming)
        {
            foreach(var entry in incoming)
            {
                if(original.ContainsKey(entry.Key))
                {
                    original[entry.Key] = incoming[entry.Key];
                }
                else
                {
                    original.Add(entry.Key, entry.Value);
                }
            }
            return original;
        }

        private static long GetTotalVolume(List<Cuboid> cuboids)
        {
            var volume = (long)0;
            foreach(var c in cuboids)
            {
                volume += c.Volume();
            }
            return volume;
        }
    }
}
