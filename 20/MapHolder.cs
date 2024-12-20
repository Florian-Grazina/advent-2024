namespace _20
{
    internal class MapHolder
    {
        public char[,] Map { get; set; }
        public (int, int) Start { get; set; }
        public (int, int) End { get; set; }

        public List<(int, int)> Directions = [];


        public Dictionary<(int, int), int> Visited = [];
        public List<ScoreData> Cheats = [];

        public MapHolder(string[] data)
        {
            Map = new char[data.Length, data[0].Length];
            GenerateMap(data);
            GenerateDirections();
            FindPath();
            Print();

            GetCheats();
        }

        #region private methods
        private void GenerateMap(string[] data)
        {
            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[0].Length; x++)
                {
                    char input = data[y][x];
                    Map[y, x] = input;
                    if (input == 'S')
                        Start = (y, x);
                    if (input == 'E')
                        End = (y, x);
                }
            }
        }

        private void GenerateDirections()
        {
            int maxRange = 20;
            for (int y = -maxRange; y <= maxRange; y++)
            {
                for (int x = -maxRange; x <= maxRange; x++)
                {
                    if (y == 0 && x == 0) // Skip the origin point
                        continue;
                    if(Math.Abs(y) + Math.Abs(x) > maxRange)
                        continue;

                    Directions.Add((y, x));
                }
            }
        }

        private void Print()
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Console.Write(Map[y, x]);
                }
                Console.WriteLine();
            }
        }

        private void GetCheats()
        {
            foreach (KeyValuePair<(int, int), int> entry in Visited)
            {
                if(entry.Key == (7,7))
                    Console.WriteLine();

                List<int> highScores = GetHigherScores(entry.Key);

                foreach(int highScore in highScores)
                {
                    int cheatScore = highScore - entry.Value;

                    if (cheatScore > 0)
                        Cheats.Add(new(entry.Key, cheatScore));
                }
            }
        }



        private void FindPath()
        {
            (int, int) actualPos = Start;
            int score = 0;

            while (true)
            {
                score++;
                Visited.Add(actualPos, score);

                if (Map[actualPos.Item1, actualPos.Item2] == 'E')
                    break;

                Map[actualPos.Item1, actualPos.Item2] = 'x';
                (int, int) availablePath = LookAround(actualPos);

                actualPos = availablePath;
            }
        }

        private List<int> GetHigherScores((int, int) coords)
        {
            List<int> higherScores = [];

            foreach (var direction in Directions)
            {
                var neighbor = (coords.Item1 + direction.Item1, coords.Item2 + direction.Item2);

                int nbOFSteps = Math.Abs(direction.Item1) + Math.Abs(direction.Item2);

                if (Visited.TryGetValue(neighbor, out int score))
                    higherScores.Add(score - nbOFSteps);
            }

            return higherScores;
        }

        private (int, int) LookAround((int, int) coords)
        {
            // look left
            if (Map[coords.Item1, coords.Item2 - 1] != '#' && Map[coords.Item1, coords.Item2 - 1] != 'x')
                return (coords.Item1, coords.Item2 - 1);

            // look right
            if (Map[coords.Item1, coords.Item2 + 1] != '#' && Map[coords.Item1, coords.Item2 + 1] != 'x')
                return ((coords.Item1, coords.Item2 + 1));

            // look up
            if (Map[coords.Item1 - 1, coords.Item2] != '#' && Map[coords.Item1 - 1, coords.Item2] != 'x')
                return (coords.Item1 - 1, coords.Item2);

            // look down
            if (Map[coords.Item1 + 1, coords.Item2] != '#' && Map[coords.Item1 + 1, coords.Item2] != 'x')
                return (coords.Item1 + 1, coords.Item2);

            throw new Exception("not path found");
        }
        #endregion
    }
}
