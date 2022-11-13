using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_CrabCombat
{
    public static class Helper
    {
        public static (Player, Player) Parse(List<string> entries)
        {
            var cards = new List<int>();
            var players = new List<Player>();
            foreach(var entry in entries)
            {
                if (entry == "")
                {
                    players.Add(new Player(cards));
                    cards = new List<int>();
                }
                else if (!entry.Contains("Player"))
                {
                    cards.Add(Convert.ToInt32(entry));
                }
            }
            players.Add(new Player(cards));
            return (players[0], players[1]);
        }

        public static int Part1(Player a, Player b)
        {
            Player winnar = null;
            while(winnar == null)
            {
                var aCard = a.Cards[0];
                var bCard = b.Cards[0];
                if(aCard > bCard)
                {
                    a.Cards.Add(aCard);
                    a.Cards.Add(bCard);
                    a.Cards.RemoveAt(0);
                    b.Cards.RemoveAt(0);
                }
                else if(aCard < bCard)
                {
                    b.Cards.Add(bCard);
                    b.Cards.Add(aCard);
                    b.Cards.RemoveAt(0);
                    a.Cards.RemoveAt(0);
                }
                if (a.Cards.Count == 0)
                {
                    winnar = b;
                } 
                else if (b.Cards.Count == 0)
                {
                    winnar = a;
                }
            }

            var i = 1;
            var result = 0;
            for(var j = winnar.Cards.Count - 1; j >=0; j--)
            {
                result += (i * winnar.Cards[j]);
                i++;
            }
            return result;
        }
    }
}
