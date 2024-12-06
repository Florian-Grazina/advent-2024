

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


        public int Run()
        {
            AddCoords();
            try
            {
                while (true)
                {
                    guard.Move();

                    if (map[guard.Y, guard.X] == '#')
                    {
                        guard.MoveBackAndTurn();
                        lastTurnCoords = guard.GetPosition();
                    }
                    else CheckLoop();

                    AddCoords();
                }
            }
            catch (IndexOutOfRangeException)
            {
                return result;
            }
            throw new Exception("no");
        }

        private void CheckLoop()
        {
            if (coordsDico.ContainsKey(guard.GetPosition()))
            {
                result++;
                RollBackGuard();
                coordsDico.Clear();
            }
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
