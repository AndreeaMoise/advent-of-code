using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_ReactorReboot
{
    public class Cuboid
    {
        public int X1, X2;
        public int Y1, Y2;
        public int Z1, Z2;

        public Cuboid(int x1, int x2, int y1, int y2, int z1, int z2)
        {
            X1 = x1; X2 = x2;
            Y1 = y1; Y2 = y2;
            Z1 = z1; Z2 = z2;
        }

        public long Volume()
        {
            return (long)(X2 - X1 + 1) * (Y2 - Y1 + 1) * (Z2 - Z1 + 1);
        }

        public bool Overlaps(Cuboid cube)
        {
            return X1 <= cube.X2 && X2 >= cube.X1
                && Y1 <= cube.Y2 && Y2 >= cube.Y1
                && Z1 <= cube.Z2 && Z2 >= cube.Z1;
        }

        public Cuboid Intersection(Cuboid cube)
        {
            return new Cuboid(Math.Max(X1, cube.X1), Math.Min(X2, cube.X2),
            Math.Max(Y1, cube.Y1), Math.Min(Y2, cube.Y2),
            Math.Max(Z1, cube.Z1), Math.Min(Z2, cube.Z2));
        }
    }
}
