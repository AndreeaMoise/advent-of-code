using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_GiantSquid
{
    public static class Helper
    {
        public static Bingo Parse(List<string> entries)
        {
            var cards = new List<Card>();
            var rows = new List<List<int>>();

            var numbers = entries[0].Split(',').Select(int.Parse).ToList();
            for(var i = 2; i < entries.Count; i++)
            {
                if(entries[i] == "")
                {
                    cards.Add(new Card(rows));
                    rows = new List<List<int>>();
                }
                else
                {
                    rows.Add(entries[i].Split(' ').Where(x => x != "").Select(int.Parse).ToList());
                }
            }
            cards.Add(new Card(rows));
            return new Bingo(numbers, cards);
        }

        public static int Part1(Bingo bingo)
        {
            var lastDrawn = -1; 
            foreach(var number in bingo.Numbers)
            {
                foreach(var card in bingo.Cards)
                {
                    var (row, col) = FindInCard(card, number);
                    if(row != -1)
                    {
                        card.Rows[row]++;
                        card.Columns[col]++;
                        card.Numbers[row][col] = -1;
                        lastDrawn = number;
                        if(card.Rows[row] == 5 || card.Columns[col] == 5)
                        {
                            return CalculateScore(card, lastDrawn);
                        }
                    }
                }
            }
            return lastDrawn;
        }

        public static int Part2(Bingo bingo)
        {
            foreach (var number in bingo.Numbers)
            {
                foreach (var card in bingo.Cards)
                {
                    var (row, col) = FindInCard(card, number);
                    if (row != -1)
                    {
                        card.Rows[row]++;
                        card.Columns[col]++;
                        card.Numbers[row][col] = -1;
                        var lastDrawn = number;
                        if ((card.Rows[row] == 5 || card.Columns[col] == 5) && card.Score == 0)
                        {
                            card.Score = CalculateScore(card, lastDrawn);
                            bingo.Scores.Add(card.Score);
                        }
                    }
                }
            }
            return bingo.Scores.Last();
        }

        private static (int, int) FindInCard(Card card, int number)
        {
            for(var row = 0; row < card.Numbers.Count; row++)
            {
                for(var column = 0; column < card.Numbers[0].Count; column++)
                {
                    if (card.Numbers[row][column] == number)
                    {
                        return (row, column);
                    }
                }
            }
            return (-1, -1);
        }

        private static int CalculateScore(Card card, int lastDrawn)
        {
            var sum = 0;
            for (var row = 0; row < card.Numbers.Count; row++)
            {
                for (var col = 0; col < card.Numbers[0].Count; col++)
                {
                    sum += (card.Numbers[row][col] != -1 ? card.Numbers[row][col] : 0);
                }
            }
            return sum * lastDrawn;
        }
    }
}
