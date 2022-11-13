using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_CrabCombat
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = new List<string>()
            {
                "Player 1:",
"26",
"16",
"33",
"8",
"5",
"46",
"12",
"47",
"39",
"27",
"50",
"10",
"34",
"20",
"23",
"11",
"43",
"14",
"18",
"1",
"48",
"28",
"31",
"38",
"41",
"",
"Player 2:",
"45",
"7",
"9",
"4",
"15",
"19",
"49",
"3",
"36",
"25",
"24",
"2",
"21",
"37",
"35",
"44",
"29",
"13",
"32",
"22",
"17",
"30",
"42",
"40",
"6"
            };

            var (playerA, playerB) = Helper.Parse(entries);
            var result = Helper.Part1(playerA, playerB);
        }
    }
}
