using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    internal class Range
    {
        public int MinY { get; set; }
        public int MaxY { get; set; }
        public int MinX { get; set; }
        public int MaxX { get; set; }

        public Range(int minY, int maxY, int minX, int maxX)
        {
            MinY = minY;
            MaxY = maxY;
            MinX = minX;
            MaxX = maxX;
        }
    }
}
