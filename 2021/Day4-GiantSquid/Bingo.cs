using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_GiantSquid
{
    public class Bingo
    {
        public List<int> Numbers { get; }
        public List<Card> Cards { get; }
        public List<int> Scores { get; }
        public Bingo(List<int> numbers, List<Card> cards)
        {
            Numbers = numbers;
            Cards = cards;
            Scores = new List<int>();
        }
    }
}
