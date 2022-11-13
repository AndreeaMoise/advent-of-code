using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_SevenSegmentSearch
{
    public static class Helper
    {
        public static List<Segment> Parse(List<string> entries)
        {
            var segments = new List<Segment>();
            foreach (var entry in entries)
            {
                var segment = entry.Split(new string[] { "| " }, StringSplitOptions.None);
                segments.Add(new Segment(segment[0].Split(' ').ToList(), segment[1].Split(' ').ToList()));
            }
            return segments;
        }
        public static int Part1(List<Segment> segments)
        {
            var count = 0;
            foreach (var segment in segments)
            {
                foreach (var output in segment.Output)
                {
                    if (output.Length == 2 || output.Length == 3 || output.Length == 4 || output.Length == 7)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static int Part2(List<Segment> segments)
        {
            var s = 0;
            foreach (var segment in segments)
            {
                var mapping = GetMapping(segment);
                var number = GetOutputNumber(mapping, segment.Output);
                s += number;
            }
            return s;
        }
        private static Dictionary<string, int> GetMapping(Segment segment)
        {
            var charCount = GetCharCount(segment.Input);
            var map = new Dictionary<char, char>();

            map.Add('b', GetB(charCount));
            map.Add('e', GetE(charCount));
            map.Add('f', GetF(charCount));

            var one = segment.Input.FirstOrDefault(i => i.Length == 2);
            var seven = segment.Input.FirstOrDefault(i => i.Length == 3);
            map.Add('a', GetA(one, seven));
            map.Add('c', GetC(charCount, map['a']));

            var four = segment.Input.FirstOrDefault(i => i.Length == 4);
            map.Add('d', GetD(charCount, four));
            map.Add('g', GetG(charCount, map['d']));

            var two = new string(new char[]{ map['a'], map['c'], map['d'], map['e'], map['g'] });
            var three = new string(new char[] { map['a'], map['c'], map['d'], map['f'], map['g'] });
            var five = new string(new char[] { map['a'], map['b'], map['d'], map['f'], map['g'] });
            var zero = new string(new char[] { map['a'], map['b'], map['c'], map['e'], map['f'], map['g'] });
            var six = new string(new char[] { map['a'], map['b'], map['d'], map['e'], map['f'], map['g'] });
            var nine = new string(new char[] { map['a'], map['b'], map['c'], map['d'], map['f'], map['g'] });
            var eight = new string(new char[] { map['a'], map['b'], map['c'], map['d'], map['e'], map['f'], map['g'] });

            return new Dictionary<string, int>()
            {
                { string.Concat(zero.OrderBy(c => c)), 0 },
                { string.Concat(one.OrderBy(c => c)), 1 },
                { string.Concat(two.OrderBy(c => c)), 2 },
                { string.Concat(three.OrderBy(c => c)), 3 },
                { string.Concat(four.OrderBy(c => c)), 4 },
                { string.Concat(five.OrderBy(c => c)), 5 },
                { string.Concat(six.OrderBy(c => c)), 6 },
                { string.Concat(seven.OrderBy(c => c)), 7 },
                { string.Concat(eight.OrderBy(c => c)), 8 },
                { string.Concat(nine.OrderBy(c => c)), 9 },
            };
        }
        private static Dictionary<char, int> GetCharCount(List<string> input)
        {
            var dictionary = new Dictionary<char, int>()
            {
                { 'a', 0 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 }, { 'f', 0 }, { 'g', 0 },
            };
            foreach (var i in input)
            {
                foreach (var ch in i)
                {
                    dictionary[ch]++;
                }
            }
            return dictionary;
        }
        private static char GetA(string one, string seven)
        {
            foreach (var ch in seven)
            {
                if (!one.Contains(ch))
                {
                    return ch;
                }
            }
            return ' ';
        }
        private static char GetB(Dictionary<char, int> charCount)
        {
            foreach (var entry in charCount)
            {
                if (entry.Value == 6)
                    return entry.Key;
            }
            return ' ';
        }
        private static char GetC(Dictionary<char, int> charCount, char excluding)
        {
            foreach (var entry in charCount)
            {
                if (entry.Value == 8 && entry.Key != excluding)
                    return entry.Key;
            }
            return ' ';
        }
        private static char GetD(Dictionary<char, int> charCount, string including)
        {
            foreach (var entry in charCount)
            {
                if (entry.Value == 7 && including.Contains(entry.Key))
                    return entry.Key;
            }
            return ' ';
        }
        private static char GetE(Dictionary<char, int> charCount)
        {
            foreach (var entry in charCount)
            {
                if (entry.Value == 4)
                    return entry.Key;
            }
            return ' ';
        }
        private static char GetF(Dictionary<char, int> charCount)
        {
            foreach (var entry in charCount)
            {
                if (entry.Value == 9)
                    return entry.Key;
            }
            return ' ';
        }
        private static char GetG(Dictionary<char, int> charCount, char excluding)
        {
            foreach (var entry in charCount)
            {
                if (entry.Value == 7 && excluding != entry.Key)
                    return entry.Key;
            }
            return ' ';
        }
        private static int GetOutputNumber(Dictionary<string, int> mapping, List<string> output)
        {
            var sum = 0;
            foreach(var entry in output)
            {
                var key = string.Concat(entry.OrderBy(c => c));
                sum = sum * 10 + mapping[key];
            };
            return sum;
        }
    }
}
