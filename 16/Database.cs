using System.Xml.Serialization;

namespace _16
{
    internal static class Database
    {
        public static List<Dictionary<(int, int), Direction>> Data { get; set; } = new();

        public static long GetScore()
        {
            long minScore = long.MaxValue;

            foreach (var set in Data)
            {
                int steps = set.Count;
                int numberOfTurns = 0;

                Direction direction = set.First().Value;

                foreach (var path in set.Values)
                {
                    if (path == direction)
                    {
                        direction = path;
                        continue;
                    }
                    else
                    {
                        numberOfTurns++;
                        direction = path;
                    }
                }

                int score = steps + (numberOfTurns * 1000);
                if(score < minScore)
                    minScore = score;
            }

            return minScore;
        }
    }
}
