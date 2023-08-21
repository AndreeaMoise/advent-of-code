using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_RegolithReservoir
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = File.ReadAllLines(Path.Combine("../../", "input2.txt")).ToList();

            var part1 = Solvers.Part1(Solvers.Parse(entries));
            Trace.WriteLine($"Part 1: {part1}");

            //var part2 = Solvers.Part2(Solvers.Parse(entries));
            //Trace.WriteLine($"Part 2: {part2}");
        }
    }
}
