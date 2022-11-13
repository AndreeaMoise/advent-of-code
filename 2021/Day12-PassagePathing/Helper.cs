using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_PassagePathing
{
    public static class Helper
    {
        private static readonly List<List<string>> paths = new List<List<string>>();
        public static Dictionary<string, List<string>> Parse(List<string> entries)
        {
            var connections = new Dictionary<string, List<string>>();
            foreach (var entry in entries)
            {
                var split = entry.Split('-');
                if(connections.ContainsKey(split[0]))
                {
                    connections[split[0]].Add(split[1]);
                }
                else
                {
                    connections.Add(split[0], new List<string>() { split[1] });
                }
                if (connections.ContainsKey(split[1]))
                {
                    connections[split[1]].Add(split[0]);
                }
                else
                {
                    connections.Add(split[1], new List<string>() { split[0] });
                }
            }
            return connections;
        }

        public static int Part1(Dictionary<string, List<string>> connections)
        {
            BackPart1(new List<string>() { "start" }, "start", connections);
            return paths.Count;
        }
        public static int Part2(Dictionary<string, List<string>> connections)
        {
            BackPart2(new List<string>() { "start" }, "start", connections);
            return paths.Count;
        }
        private static void BackPart1(List<string> path, string cave, Dictionary<string, List<string>> connections)
        {
            foreach (var newCave in connections[cave])
            {
                if (!(newCave == "start" || IsLowerCase(newCave) && path.Contains(newCave)))
                {
                    if (newCave == "end")
                    {
                        paths.Add(new List<string>(path) { newCave });
                    }
                    else
                    {
                        BackPart1(new List<string>(path) { newCave }, newCave, connections);
                    }
                }
            }
        }
        private static void BackPart2(List<string> path, string cave, Dictionary<string, List<string>> connections)
        {
            foreach (var newCave in connections[cave])
            {
                if (newCave != "start")
                {
                    if (IsLowerCase(newCave) && ContainsOtherSmallCaves(path, newCave))
                    {
                        continue;
                    }
                    if (newCave == "end")
                    {
                        paths.Add(new List<string>(path) { newCave });
                    }
                    else
                    {
                        BackPart2(new List<string>(path) { newCave }, newCave, connections);
                    }
                }
            }
        }
        private static bool IsLowerCase(string s)
        {
            return !s.Any(ch => ch >= 'A' && ch <= 'Z');
        }
        private static bool ContainsOtherSmallCaves(List<string> path, string cave)
        {
            var visited = new Dictionary<string, int>();
            foreach (var s in path)
            {
                if(s != "start" && s != "end" && IsLowerCase(s))
                {
                    if(visited.ContainsKey(s))
                    {
                        visited[s]++;
                    }
                    else
                    {
                        visited.Add(s, 1);
                    }
                }
            }
            var count = 0;
            foreach(var entry in visited)
            {
                if(entry.Value == 2)
                {
                    if(entry.Key == cave)
                    {
                        return true;
                    }
                    count++;
                }
            }
            return count > 1;
        }
    }
}
