using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_DumboOctopus
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = new List<string>()
            {
                "5483143223",
                "2745854711",
                "5264556173",
                "6141336146",
                "6357385478",
                "4167524645",
                "2176841721",
                "6882881134",
                "4846848554",
                "5283751526"
            };
            var entries2 = new List<string>()
            {
                "11111",
                "19991",
                "19191",
                "19991",
                "11111"
            };
            var entries3 = new List<string>()
            {
                "1172728874",
                "6751454281",
                "2612343533",
                "1884877511",
                "7574346247",
                "2117413745",
                "7766736517",
                "4331783444",
                "4841215828",
                "6857766273"
            };
            var result = Helper.Part2(Helper.Parse(entries3));
        }
    }
}
