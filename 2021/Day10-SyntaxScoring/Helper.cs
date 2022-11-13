using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_SyntaxScoring
{
    public static class Helper
    {
        private static readonly List<char> openings = new List<char>() { '(', '[', '{', '<' };
        private static readonly List<char> closings = new List<char>() { ')', ']', '}', '>' };
        public static int Part1(List<string> entries)
        {
            var corrupted = new List<char>();
            foreach (var entry in entries)
            {
                var stack = new Stack<char>();
                foreach(var ch in entry)
                {
                    if(openings.Contains(ch))
                    {
                        stack.Push(ch);
                    }
                    else // Assume closing
                    {
                        var indexOfClosing = closings.IndexOf(ch);
                        if(stack.Peek() != openings[indexOfClosing])
                        {
                            corrupted.Add(ch);
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            return GetCorruptedScore(corrupted);
        }
        public static double Part2(List<string> entries)
        {
            var incomplete = new List<string>();
            foreach (var entry in entries)
            {
                var stack = new Stack<char>();
                var isCorrupted = false;
                foreach (var ch in entry)
                {
                    if (openings.Contains(ch))
                    {
                        stack.Push(ch);
                    }
                    else // Assume closing
                    {
                        var indexOfClosing = closings.IndexOf(ch);
                        if (stack.Peek() != openings[indexOfClosing])
                        {
                            isCorrupted = true;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }
                if(!isCorrupted)
                {
                    incomplete.Add(entry);
                }
            }

            return GetIncompleteScore(incomplete);
        }
        private static int GetCorruptedScore(List<char> corrupted)
        {
            var score = 0;
            foreach(var ch in corrupted)
            {
                switch(ch)
                {
                    case ')':
                        score += 3;
                        break;
                    case ']':
                        score += 57;
                        break;
                    case '}':
                        score += 1197;
                        break;
                    default:
                        score += 25137;
                        break;
                }
            }
            return score;
        }
        private static double GetIncompleteScore(List<string> incomplete)
        {
            var scores = new List<double>();
            foreach (var entry in incomplete)
            {
                var stack = new Stack<char>();
                var score = 0.0;
                foreach (var ch in entry)
                {
                    if (openings.Contains(ch))
                    {
                        stack.Push(ch);
                    }
                    else // Assume correct closing
                    {
                        stack.Pop();
                    }
                }
                while (stack.Count > 0)
                {
                    var peek = stack.Pop();
                    var indexOpening = openings.IndexOf(peek);
                    score *= 5;
                    switch (closings[indexOpening])
                    {
                        case ')':
                            score += 1;
                            break;
                        case ']':
                            score += 2;
                            break;
                        case '}':
                            score += 3;
                            break;
                        default:
                            score += 4;
                            break;
                    }
                }
                scores.Add(score);
            }
            scores.Sort();
            return scores[scores.Count / 2];
        }
    }
}
