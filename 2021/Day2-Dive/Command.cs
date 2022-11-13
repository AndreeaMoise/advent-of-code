using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Dive
{
    public class Command
    {
        public string Type { get; }
        public int Amount { get; }
        public Command(string type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
