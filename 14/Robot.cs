using System.Text.RegularExpressions;

namespace _14
{
    internal class Robot
    {
        public (int, int) Coords { get; set; }
        public (int ,int) Velocity { get; set; }

        public Robot(string data)
        {
            ParseData(data);
        }

        public void Move()
        {
            Coords = (Coords.Item1 + Velocity.Item1, Coords.Item2 + Velocity.Item2);
        }

        public short GetQuadrantId(Dictionary<short, Range> quadrantsDico)
        {
            foreach(KeyValuePair<short, Range> quadrant in quadrantsDico)
            {
                if (IsIn(quadrant))
                    return quadrant.Key;
            }
            return 0;
        }

        private bool IsIn(KeyValuePair<short, Range> quadrant)
        {
            if (Coords.Item1 >= quadrant.Value.MinY && Coords.Item1 <= quadrant.Value.MaxY &&
                Coords.Item2 >= quadrant.Value.MinX && Coords.Item2 <= quadrant.Value.MaxX)
                return true;
            return false;
        }

        private void ParseData(string data)
        {
            Regex regex = new(@"(-?\d)");
            MatchCollection matches = regex.Matches(data);

            Coords = (int.Parse(matches[1].Value), int.Parse(matches[0].Value));
            Velocity = (int.Parse(matches[3].Value), int.Parse(matches[2].Value));
        }
    }
}
