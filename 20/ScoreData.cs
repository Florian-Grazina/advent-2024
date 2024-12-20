using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20
{
    internal class ScoreData
    {
        public ScoreData((int, int) coords, int score)
        {
            Coords = coords;
            Score = score;
        }

        public (int, int) Coords { get; set; }

        public int Score { get; set; }
    }
}
