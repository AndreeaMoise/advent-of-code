using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_ExtendedPolymerization
{
    public static class Helper
    {
        public static (string, Dictionary<string, char>) Parse(List<string> entries)
        {
            var template = "";
            var pairs = new Dictionary<string, char>();
            foreach(var entry in entries)
            {
                if(entry.Contains("->"))
                {
                    pairs.Add(entry.Substring(0, 2), entry.Last());
                }
                else
                {
                    if(entry != "")
                    {
                        template = entry;
                    }
                }
            }
            return (template, pairs);
        }
        public static long Part1(string template, Dictionary<string, char> pairs)
        {
            var count = 0;
            while(count < 10)
            {
                var i = 0;
                while (i < template.Length - 1)
                {
                    var key = template.Substring(i, 2);
                    if (pairs.ContainsKey(key))
                    {
                        template = template.Insert(i + 1, pairs[key].ToString());
                        i += 2;
                    }
                    else
                    {
                        i++;
                    }
                }
                count++;
            }
            return DiffCommonElements(template);
        }
        public static long Part2(string template, Dictionary<string, char> rules)
        {   
            var count = 0;
            var charactersCount = CharactersCount(template);
            var pairs = PairsCount(template); // NN: 2, NC: 1
            while (count < 40)
            {
                Trace.WriteLine(count.ToString());
                var newPairs = new Dictionary<string, long>();
                foreach (var pair in pairs) // key, value
                {
                    if (rules.ContainsKey(pair.Key))
                    {
                        var newKey1 = pair.Key[0].ToString() + rules[pair.Key].ToString();
                        var newKey2 = rules[pair.Key].ToString() + pair.Key[1].ToString();

                        if (newPairs.ContainsKey(newKey1))
                        {
                            newPairs[newKey1] += pair.Value; 
                        }
                        else
                        {
                            newPairs.Add(newKey1, pair.Value);
                        }

                        if (newPairs.ContainsKey(newKey2))
                        {
                            newPairs[newKey2] += pair.Value;
                        }
                        else
                        {
                            newPairs.Add(newKey2, pair.Value);
                        }

                        if(charactersCount.ContainsKey(rules[pair.Key]))
                        {
                            charactersCount[rules[pair.Key]] += pair.Value;
                        }
                        else
                        {
                            charactersCount.Add(rules[pair.Key], pair.Value);
                        }                        
                    }
                    else
                    {
                        newPairs.Add(pair.Key, pair.Value);
                    }
                }
                pairs = newPairs;
                count++;    
            }
            return DiffCommonElements(charactersCount);
        }
        private static long DiffCommonElements(string template)
        {
            var dictionary = CharactersCount(template).OrderByDescending(key => key.Value).ToDictionary(z => z.Key, y => y.Value);
            return dictionary.ElementAt(0).Value-dictionary.Last().Value;
        }
        private static long DiffCommonElements(Dictionary<char, long> characterCount)
        {
            var sorted = characterCount.OrderByDescending(key => key.Value).ToDictionary(z => z.Key, y => y.Value);
            return sorted.ElementAt(0).Value - sorted.Last().Value;
        }
        private static Dictionary<char, long> CharactersCount(string template)
        {
            var dictionary = new Dictionary<char, long>();
            foreach (var ch in template)
            {
                if (dictionary.ContainsKey(ch))
                {
                    dictionary[ch]++;
                }
                else
                {
                    dictionary.Add(ch, 1);
                }
            }
            return dictionary;
        }
        private static Dictionary<string, long> PairsCount(string template)
        {
            var dictionary = new Dictionary<string, long>();
            for (var i = 0; i < template.Length - 1; i++)
            {
                var key = template.Substring(i, 2);
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key]++;
                }
                else
                {
                    dictionary.Add(key, 1);
                }
            }
            return dictionary;
        }
    }
}
