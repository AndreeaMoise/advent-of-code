using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Dive
{
    public static class Helper
    {
        public static List<Command> Parse(List<string> entries)
        {
            var commands = new List<Command>();
            foreach(var entry in entries)
            {
                var split = entry.Split(' ');
                commands.Add(new Command(split[0], Convert.ToInt32(split[1])));
            }
            return commands;
        }
        public static int Part1(List<Command> commands)
        {
            var depth = 0;
            var horizontal = 0;
            foreach(var command in commands)
            {
                switch(command.Type)
                {
                    case "forward":
                        horizontal += command.Amount;
                        break;
                    case "up":
                        depth -= command.Amount;
                        break;
                    case "down":
                        depth += command.Amount;
                        break;
                }
            }
            return depth * horizontal;
        }

        public static int Part2(List<Command> commands)
        {
            var depth = 0;
            var horizontal = 0;
            var aim = 0;
            foreach (var command in commands)
            {
                switch (command.Type)
                {
                    case "forward":
                        horizontal += command.Amount;
                        depth += (aim * command.Amount);
                        break;
                    case "up":
                        aim -= command.Amount;
                        break;
                    case "down":
                        aim += command.Amount;
                        break;
                }
            }
            return depth * horizontal;
        }
    }
}
