using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_GiantSquid
{
    public class Card
    {
        public List<List<int>> Numbers { get; }
        public Dictionary<int, int> Rows { get; }
        public Dictionary<int, int> Columns { get; }
        public int Score { get; set; }
        public Card(List<List<int>> numbers)
        {
            Numbers = numbers;
            Rows = new Dictionary<int, int>();
            Rows.Add(0, 0);
            Rows.Add(1, 0);
            Rows.Add(2, 0);
            Rows.Add(3, 0);
            Rows.Add(4, 0);

            Columns = new Dictionary<int, int>();
            Columns.Add(0, 0);
            Columns.Add(1, 0);
            Columns.Add(2, 0);
            Columns.Add(3, 0);
            Columns.Add(4, 0);
        }
    }
}
