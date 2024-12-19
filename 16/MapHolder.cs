
namespace _16
{
    internal class MapHolder
    {
        public char[,] Map { get; set; }
        public Reindeer Reindeer { get; set; }
        public (int, int) GoalCoords { get; set; }

        public MapHolder(string[] data)
        {
            Map = new char[data.Length, data[0].Length];
            (int, int) reindeerPos = ParseData(data);
            Reindeer = new(reindeerPos, Direction.RIGHT, Map, []);
        }

        #region public methods
        private (int, int) ParseData(string[] data)
        {
            (int, int) reindeerPos = (0, 0);

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[0].Length; x++)
                {
                    char input = data[y][x];
                    Map[y, x] = input;

                    if (input == 'S')
                        reindeerPos = (y, x);

                    else if (input == 'E')
                        GoalCoords = (y, x);
                }
            }
            return reindeerPos;
        }
        #endregion
    }
}
