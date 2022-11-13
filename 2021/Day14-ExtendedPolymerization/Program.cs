﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_ExtendedPolymerization
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = new List<string>()
            {
                "NNCB",
                "",
                "CH -> B",
                "HH -> N",
                "CB -> H",
                "NH -> C",
                "HB -> C",
                "HC -> B",
                "HN -> C",
                "NN -> C",
                "BH -> H",
                "NC -> B",
                "NB -> B",
                "BN -> B",
                "BB -> N",
                "BC -> B",
                "CC -> N",
                "CN -> C"
            };
            var entries2 = new List<string>()
            {
                "FPNFCVSNNFSFHHOCNBOB",
"",
"ON -> S",
"SO -> B",
"OH -> C",
"SN -> F",
"BP -> O",
"SK -> F",
"OO -> K",
"CF -> O",
"PP -> F",
"KS -> K",
"KN -> B",
"BN -> H",
"HN -> H",
"NP -> P",
"BB -> N",
"SB -> F",
"BH -> V",
"NV -> S",
"PO -> S",
"CN -> N",
"VP -> B",
"HH -> B",
"NB -> V",
"NF -> O",
"BV -> B",
"CV -> B",
"SS -> H",
"CB -> C",
"VN -> S",
"FH -> K",
"BF -> H",
"NH -> P",
"PV -> K",
"OP -> F",
"HO -> N",
"SH -> C",
"VH -> P",
"VK -> B",
"OF -> F",
"KK -> B",
"SC -> H",
"CO -> S",
"BK -> V",
"PF -> B",
"OK -> K",
"FO -> V",
"CH -> O",
"KO -> B",
"CS -> V",
"OC -> P",
"SP -> V",
"KF -> C",
"HV -> S",
"KH -> B",
"VS -> K",
"KB -> F",
"FF -> P",
"VF -> H",
"NC -> S",
"HB -> V",
"NN -> C",
"FV -> B",
"PH -> V",
"KV -> C",
"PB -> C",
"OS -> O",
"PS -> H",
"FS -> N",
"FP -> O",
"VV -> O",
"FN -> V",
"NO -> K",
"NK -> V",
"OB -> F",
"PC -> O",
"OV -> H",
"FK -> C",
"HS -> F",
"SF -> N",
"VC -> C",
"BS -> N",
"PK -> O",
"FB -> S",
"CK -> B",
"KP -> N",
"KC -> F",
"BC -> F",
"HK -> H",
"VO -> O",
"NS -> B",
"VB -> K",
"FC -> K",
"SV -> O",
"HF -> H",
"HC -> C",
"CP -> O",
"CC -> P",
"PN -> P",
"HP -> C",
"BO -> F"
            };
            var (template, pairs) = Helper.Parse(entries2);
            var result = Helper.Part2(template, pairs);
        }
    }
}
