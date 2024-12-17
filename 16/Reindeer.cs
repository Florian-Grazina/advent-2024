
using System.IO;

namespace _16
{
    internal class Reindeer
    {
        public Direction Direction { get; set; }
        public HashSet<(int, int)> Path { get; set; }
        public (int, int) Coords { get; set; }
        public int Score { get; set; }
        public char[,] Map { get; set; }
        public int Y => Coords.Item1;
        public int X => Coords.Item2;

        public Reindeer((int, int) coords, Direction dir, char[,] map, HashSet<(int, int)> path, int score)
        {
            Score = score;
            Coords = coords;
            Direction = dir;
            Map = CopyCharArray(map);
            Path = new(path);
        }

        public void Run()
        {
            //Print(Map);
            FindPathRecurs(Map, Coords, Direction);
        }

        private void FindPathRecurs(char[,] map, (int, int) coords, Direction direction)
        {
            if (Score >= Database.Score)
                return;

            if (Database.History.TryGetValue(coords, out int value))
            {
                if (Score > value)
                    return;
                else
                    Database.History[coords] = Score;
            } 
            else
                Database.History.Add(coords, Score);

            if (map[coords.Item1, coords.Item2] == 'E')
            {
                //Print(map);
                Console.WriteLine(Score);
                Database.SetBestScore(Score);
                return;
            }

            if (map[coords.Item1, coords.Item2] == '#')
                return;

            map[coords.Item1, coords.Item2] = '#';
            Path.Add(coords);

            Score++;

            //Print(map);
            List<(int, int)> availablePaths = LookAround(map, coords);
            if (availablePaths.Count == 0)
                return;

            foreach (var path in availablePaths.Skip(1))
            {
                int newScore = Score;

                Direction newDir = GetDirection(coords, path);
                if (newDir != direction)
                    newScore += 1000;

                Reindeer newRein = new(path, newDir, map, Path, newScore);
                newRein.Run();
            }

            (int, int) pathz = availablePaths.First();

            Direction newDirz = GetDirection(coords, pathz);
            if (newDirz != direction)
                Score += 1000;

            Direction = newDirz;
            Map = map;
            Coords = pathz;

            //Print(map);
            FindPathRecurs(Map, Coords, Direction);
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

        private Direction GetDirection((int y, int x) from, (int y, int x) to)
        {
            int dx = to.x - from.x;
            int dy = to.y - from.y;

            if (dx == 0 && dy < 0) return Direction.UP;
            if (dx == 0 && dy > 0) return Direction.DOWN;
            if (dy == 0 && dx > 0) return Direction.RIGHT;
            if (dy == 0 && dx < 0) return Direction.LEFT;

            throw new ArgumentException("Points do not align with a single cardinal direction.");
        }

        private void Print(char[,] map)
        {
            Console.WriteLine("----------------------------");
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------");
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
