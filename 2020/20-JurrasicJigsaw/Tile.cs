using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20_JurrasicJigsaw
{
    public class Tile
    {
        public string Id { get; }
        public string TopEdge { get; }
        public string BottomEdge { get; }
        public string LeftEdge { get; }
        public string RightEdge { get; }
        public string TopEdgeMatch { get; set; }
        public string BottomEdgeMatch { get; set; }
        public string LeftEdgeMatch { get; set; }
        public string RightEdgeMatch { get; set; }
        public bool HasTopEdgeMatch { get; set; }
        public bool HasBottomEdgeMatch { get; set; }
        public bool HasLeftEdgeMatch { get; set; }
        public bool HasRightEdgeMatch { get; set; }
        public bool Flipped { get; set; }
        public int Rotated { get; set; } // Counter clockwise
        public Corner Corner { get; set; }

        public Tile(string id, string topEdge, string rightEdge, string leftEdge, string bottomEdge)
        {
            Id = id;
            TopEdge = topEdge;
            BottomEdge = bottomEdge;
            LeftEdge = leftEdge;
            RightEdge = rightEdge;
            BottomEdgeMatch = "";
            LeftEdgeMatch = "";
            RightEdgeMatch = "";
            TopEdgeMatch = "";
            HasBottomEdgeMatch = false;
            HasTopEdgeMatch = false;
            HasLeftEdgeMatch = false;
            HasRightEdgeMatch = false;
            Corner = Corner.NOT_A_CORNER;
            Flipped = false;
            Rotated = 0;
        }
    }
}
