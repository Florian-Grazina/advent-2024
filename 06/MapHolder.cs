namespace _06
{
    internal class MapHolder
    {
        private readonly char[,] map;
        private Guard guard = default!;
        private Dictionary<(int, int), List<Direction>> coordsDico;
        private int result = 0;

        private Dictionary<(int, int), List<Direction>> sampleRunPositions;


        public MapHolder(string[] data)
        {
            map = ParseData(data);
            coordsDico = [];
            sampleRunPositions = [];
        }

        public int RunV2()
        {
            Run(true);

            int total = sampleRunPositions.Count;
            int tries = 0;

            //for (int y = 0; y < map.GetLength(0); y++)
            //{
            //    for (int x = 0; x < map.GetLength(1); x++)
            //    {
            //        tries++;
            //        if (tries % 1000 == 0)
            //            Console.WriteLine($"Starting {tries} / {total}");

            //        if (!sampleRunPositions.TryGetValue((y, x), out _))
            //            continue;

            //        if (map[y, x] != '.')
            //            continue;

            //        map[y, x] = '#';
            //        Run();
            //        map[y, x] = '.';
            //        guard.RollBack();
            //        coordsDico.Clear();
            //    }
            //}

            foreach((int, int) pos in sampleRunPositions.Keys)
            {
                tries++;
                if (tries % 100 == 0)
                    Console.WriteLine($"Starting {tries} / {total}");

                int y = pos.Item1;
                int x = pos.Item2;

                if (map[y, x] == '.')
                {
                    map[y, x] = '#';
                    Run();
                    map[y, x] = '.';
                    guard.RollBack();
                    coordsDico.Clear();
                    map[guard.Y, guard.X] = '^';
                }
            }

            return result;
        }

        public void Run(bool isSampleRun = false)
        {
            try
            {
                while (true)
                {
                    if (isSampleRun)
                        AddSampleCoords();
                    else
                    {
                        if (CheckLoop())
                            break;

                        AddCoords();
                    }

                    guard.Move();

                    if (map[guard.Y, guard.X] == '#')
                    {
                        guard.MoveBackAndTurn();

                        if (isSampleRun)
                            AddSampleCoords();
                        else
                            AddCoords();


                        guard.Move();

                        if (map[guard.Y, guard.X] == '#')
                        {
                            guard.MoveBackAndTurn();

                            if (isSampleRun)
                                AddSampleCoords();
                            else
                                AddCoords();


                            guard.Move();
                        }
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
            if (coordsDico.TryGetValue(guard.GetPosition(), out List<Direction> oldDirections))
            {
                foreach (Direction oldDirection in oldDirections)
                {
                    if (oldDirection == guard.Direction)
                    {
                        result++;
                        return true;
                    }
                }
            }
            return false;
        }

        private void AddCoords()
        {
            (int, int) guardPosition = guard.GetPosition();

            if (coordsDico.TryGetValue(guardPosition, out List<Direction> oldDirections))
                oldDirections.Add(guard.Direction);
            else
                coordsDico.TryAdd(guardPosition, [guard.Direction]);
        }

        private void AddSampleCoords()
        {
            (int, int) guardPosition = guard.GetPosition();

            if (sampleRunPositions.TryGetValue(guardPosition, out List<Direction> oldDirections))
                oldDirections.Add(guard.Direction);
            else
                sampleRunPositions.TryAdd(guardPosition, [guard.Direction]);
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
    }
}
