using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_CrabCombat
{
    public class Player
    {
        public List<int> Cards { get; }
        public Player(List<int> cards)
        {
            Cards = cards;
        }
    }
}
