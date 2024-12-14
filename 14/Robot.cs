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

        internal void Move()
        {
            Coords = (Coords.Item1 + Velocity.Item1, Coords.Item2 + Velocity.Item2);
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
