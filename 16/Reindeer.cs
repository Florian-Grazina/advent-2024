
namespace _16
{
    internal class Reindeer
    {
        public Direction Direction { get; set; }
        public HashSet<(int, int)> Path { get; set; }
        public (int, int) Coords { get; set; }
        public char[,] Map { get; set; }
        public int Y => Coords.Item1;
        public int X => Coords.Item2;

        public Reindeer((int, int) coords, Direction dir, char[,] map, HashSet<(int, int)> path)
        {
            Coords = coords;
            Direction = dir;
            Map = CopyCharArray(map);
            Path = new(path);
        }

        public void Run()
        {
            FindPathRecurs(Map, Coords, Direction);
        }

        private void FindPathRecurs(char[,] map, (int, int) coords, Direction direction)
        {
            if (map[coords.Item1, coords.Item2] == 'E')
            {
                Database.Data.Add(Path);
                return;
            }


            map[coords.Item1, coords.Item2] = '#';
            Path.Add(coords);

            //Print(map);
            List<(int, int)> availablePaths = LookAround(map, coords);

            foreach (var path in availablePaths)
            {
                long newScore = GetNewScore(coords, path, direction);

                Reindeer newRein = new(path, direction, map, Path);
                    newRein.Run();
            }
        }

        private List<(int, int)> LookAround(char[,] map, (int, int) coords)
        {
            List<(int, int)> availablePaths = [];

            // look left
            if (map[coords.Item1, coords.Item2 - 1] != '#')
                availablePaths.Add((coords.Item1, coords.Item2 - 1));

            // look right
            if (map[coords.Item1, coords.Item2 + 1] != '#')
                availablePaths.Add((coords.Item1, coords.Item2 + 1));

            // look up
            if (map[coords.Item1 - 1, coords.Item2] != '#')
                availablePaths.Add((coords.Item1 - 1, coords.Item2));

            // look down
            if (map[coords.Item1 + 1, coords.Item2] != '#')
                availablePaths.Add((coords.Item1 + 1, coords.Item2));

            return availablePaths;
        }

        private long GetNewScore((int, int) oldCoords, (int, int) newCoords, Direction direction)
        {
            int score = 0;
            int dy = newCoords.Item1 - oldCoords.Item1;
            int dx = newCoords.Item2 - oldCoords.Item2;

            Direction newDirection = Direction.NONE;

            if (dx == 0 && dy > 0) newDirection = Direction.UP;
            if (dx == 0 && dy < 0) newDirection = Direction.DOWN;
            if (dy == 0 && dx > 0) newDirection = Direction.RIGHT;
            if (dy == 0 && dx < 0) newDirection = Direction.LEFT;

            int angle = Math.Abs((int)newDirection - (int)direction);

            if (direction == Direction.UP || newDirection == Direction.UP)
            {
                if (direction == Direction.UP && newDirection == Direction.RIGHT ||
                    direction == Direction.UP && newDirection == Direction.LEFT ||
                    newDirection == Direction.UP && direction == Direction.RIGHT ||
                    newDirection == Direction.UP && direction == Direction.RIGHT)
                    angle = 90;
            }

            int numberOfTurns = angle / 90;

            score += numberOfTurns * 1000;
            return score;
        }

        private void Print(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }

        public static char[,] CopyCharArray(char[,] original)
        {
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);
            char[,] copy = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copy[i, j] = original[i, j];
                }
            }

            return copy;
        }
    }
}
