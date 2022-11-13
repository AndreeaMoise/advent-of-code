using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_PassagePathing
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = new List<string>()
            {
                "start-A",
                "start-b",
                "A-c",
                "A-b",
                "b-d",
                "A-end",
                "b-end"
            };
            var entries2 = new List<string>()
            {
                "start-A",
                "start-b",
                "A-b",
                "A-end",
                "b-end"
            };
            var entries3 = new List<string>()
            {
                "dc-end",
                "HN-start",
                "start-kj",
                "dc-start",
                "dc-HN",
                "LN-dc",
                "HN-end",
                "kj-sa",
                "kj-HN",
                "kj-dc"
            };
            var entries4 = new List<string>()
            {
                "fs-end",
                "he-DX",
                "fs-he",
                "start-DX",
                "pj-DX",
                "end-zg",
                "zg-sl",
                "zg-pj",
                "pj-he",
                "RW-he",
                "fs-DX",
                "pj-RW",
                "zg-RW",
                "start-pj",
                "he-WI",
                "zg-he",
                "pj-fs",
                "start-RW"
            };
            var entries5 = new List<string>()
            {
                "start-qs",
                "qs-jz",
                "start-lm",
                "qb-QV",
                "QV-dr",
                "QV-end",
                "ni-qb",
                "VH-jz",
                "qs-lm",
                "qb-end",
                "dr-fu",
                "jz-lm",
                "start-VH",
                "QV-jz",
                "VH-qs",
                "lm-dr",
                "dr-ni",
                "ni-jz",
                "lm-QV",
                "jz-dr",
                "ni-end",
                "VH-dr",
                "VH-ni",
                "qb-HE"
            };
            var result = Helper.Part2(Helper.Parse(entries5));
        }
    }
}
