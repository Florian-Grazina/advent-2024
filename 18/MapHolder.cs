namespace _18
{
    internal class MapHolder
    {
        public char[,] Map { get; set; }
        public List<ByteMem> Bytes { get; set; }
        public (int, int) Start { get; set; }
        public (int, int) End { get; set; }

        public int NbOfDrop = 1024;
        public int Range = 70;

        public MapHolder(string[] data)
        {
            Start = (0, 0);
            End = (Range, Range);

            Bytes = [];
            Map = new char[Range + 1, Range + 1];

            foreach (string input in data)
                Bytes.Add(new ByteMem(input));

            GenerateMap();
            Print(Map);
        }

        #region private methods
        private void GenerateMap()
        {
            for (int y = 0; y < Range + 1; y++)
                for (int x = 0; x < Range + 1; x++)
                    Map[y, x] = '.';

            foreach (ByteMem bit in Bytes)
                Map[bit.Y, bit.X] = '#';
        }

        private void Print(char[,] map)
        {
            Console.WriteLine("--------------------");
            for (int y = 0; y < Range + 1; y++)
            {
                for (int x = 0; x < Range + 1; x++)
                    Console.Write(map[y, x]);
                Console.WriteLine();
            }
            Console.WriteLine("--------------------");
        }


        internal (int, int) FindBlockCoord()
        {
            Bytes.Reverse();

            int index = 0;
            foreach (ByteMem bit in Bytes)
            {
                index++;
                Console.WriteLine($"Testing bit n '{index}' / {Bytes.Count}");

                Map[bit.Y, bit.X] = '.';

                if (!IsBlocked(CopyCharArray(Map)))
                    return bit.Coords;
            }
            throw new Exception("No block found.");
        }


        public bool IsBlocked(char[,] map)
        {
            HashSet<(int, int)> pathsStart = [Start];
            HashSet<(int, int)> pathsEnd = [End];

            int score = 0;

            while (true)
            {
                HashSet<(int, int)> availablePathsStart = [];
                HashSet<(int, int)> availablePathsEnd = [];

                foreach ((int, int) path in pathsStart)
                {
                    map[path.Item1, path.Item2] = 'S';
                    LookAround(path, 'S', map).ForEach(p => availablePathsStart.Add(p));
                }

                foreach ((int, int) path in pathsEnd)
                {
                    map[path.Item1, path.Item2] = 'E';
                    LookAround(path, 'E', map).ForEach(p => availablePathsEnd.Add(p));
                }

                if (availablePathsStart.Count == 0)
                    return true;

                score += 2;

                pathsEnd.Clear();
                foreach ((int, int) path in availablePathsEnd)
                {
                    pathsEnd.Add(path);
                }

                pathsStart.Clear();
                foreach ((int, int) path in availablePathsStart)
                {
                    if (pathsEnd.Contains(path))
                        return false;
                    pathsStart.Add(path);
                }
            }
        }

        private List<(int, int)> LookAround((int, int) coords, char obstacle, char[,] map)
        {
            List<(int, int)> availablePaths = [];

            // look left
            try
            {
                if (map[coords.Item1, coords.Item2 - 1] != '#' && map[coords.Item1, coords.Item2 - 1] != obstacle)
                    availablePaths.Add((coords.Item1, coords.Item2 - 1));

            }
            catch { }

            // look right
            try
            {
                if (map[coords.Item1, coords.Item2 + 1] != '#' && map[coords.Item1, coords.Item2 + 1] != obstacle)
                    availablePaths.Add((coords.Item1, coords.Item2 + 1));

            }
            catch
            {

            }

            // look up
            try
            {

                if (map[coords.Item1 - 1, coords.Item2] != '#' && map[coords.Item1 - 1, coords.Item2] != obstacle)
                    availablePaths.Add((coords.Item1 - 1, coords.Item2));
            }
            catch
            {

            }

            // look down
            try
            {

                if (map[coords.Item1 + 1, coords.Item2] != '#' && map[coords.Item1 + 1, coords.Item2] != obstacle)
                    availablePaths.Add((coords.Item1 + 1, coords.Item2));
            }
            catch
            {

            }

            return availablePaths;
        }

        public char[,] CopyCharArray(char[,] source)
        {
            int rows = source.GetLength(0);
            int cols = source.GetLength(1);
            char[,] copy = new char[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    copy[i, j] = source[i, j];

            return copy;
        }
        #endregion
    }
}
