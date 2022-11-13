using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_HydrothermalVenture
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public int Visited { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
            Visited = 0;
        }
    }
}
