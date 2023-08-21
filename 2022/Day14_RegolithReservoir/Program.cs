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
            var parsedEntries = Solvers.Parse(entries);
            var part1 = Solvers.Part1V2(parsedEntries.Item1, parsedEntries.Item2);
            Trace.WriteLine($"Part 1: {part1}");

            //var part2 = Solvers.Part2(Solvers.Parse(entries));
            //Trace.WriteLine($"Part 2: {part2}");
        }
    }
}
