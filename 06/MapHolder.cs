

using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _06
{
    internal class MapHolder
    {
        private readonly char[,] map;
        private Guard guard = default!;
        private Dictionary<(int, int), Direction> coordsDico;
        private int result = 0;

        private (int, int) lastTurnCoords;


        public MapHolder(string[] data)
        {
            map = ParseData(data);
            coordsDico = [];
        }

        public int RunV2()
        {
            int total = map.GetLength(0) * map.GetLength(1);
            int tries = 0;

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    tries++;
                    Console.WriteLine($"Starting {tries} / {total}");

                    if (map[y, x] != '.')
                        continue;

                    map[y, x] = '#';
                    Run();
                    map[y, x] = '.';
                    guard.RollBack();
                    coordsDico.Clear();
                }
            }

            return result;
        }

        public int RunV3()
        {
            try
            {
                while (true)
                {
                    if (CheckLoopV3())
                        result++;

                    AddCoords();

                    guard.Move();

                    if (map[guard.Y, guard.X] == '#')
                    {
                        guard.MoveBackAndTurn();
                        guard.Move();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return result;
            }
            throw new Exception("impossible");
        }

        public bool CheckLoopV3()
        {
            Direction directionAfterTurn = guard.GetDirectionAfterTurn();
            (int, int) position = guard.GetPosition();

            if (CheckIfInDicoRecursive(position, directionAfterTurn))
                return true;

            return false;
        }

        private bool CheckIfInDicoRecursive((int, int) position, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    position.Item1--;
                    break;
                case Direction.Down:
                    position.Item1++;
                    break;
                case Direction.Left:
                    position.Item2--;
                    break;
                case Direction.Right:
                    position.Item2++;
                    break;
            }

            try
            {
                if (coordsDico.TryGetValue(position, out Direction oldDirection))
                {
                    if (oldDirection == direction)
                        return true;
                }

                else if (map[position.Item1, position.Item2] == '#')
                    return false;

                return CheckIfInDicoRecursive(position, direction);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }


        public void Run()
        {
            try
            {
                while (true)
                {
                    if (CheckLoop())
                        break;

                    AddCoords();

                    guard.Move();

                    if (map[guard.Y, guard.X] == '#')
                    {
                        guard.MoveBackAndTurn();
                        guard.Move();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            return;
        }

        private bool CheckLoop()
        {
            if (coordsDico.TryGetValue(guard.GetPosition(), out Direction oldFirection))
            {
                if (guard.Direction == oldFirection)
                {
                    result++;
                    return true;
                }
            }
            return false;
        }

        private void RollBackGuard()
        {
            guard.Y = lastTurnCoords.Item1;
            guard.X = lastTurnCoords.Item2;
            guard.Direction = coordsDico[guard.GetPosition()];
        }

        private void AddCoords()
        {
            (int, int) guardPosition = guard.GetPosition();
            coordsDico.TryAdd(guardPosition, guard.Direction);
        }

        private char[,] ParseData(string[] data)
        {
            var map = new char[data.Length, data[0].Length];

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    map[y, x] = data[y][x];

                    if (data[y][x] != '.' && data[y][x] != '#')
                        guard = new(y, x, data[y][x]);
                }
            }
            return map;
        }

        private void PrintMap()
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
