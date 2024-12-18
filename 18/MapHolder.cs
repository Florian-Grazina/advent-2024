

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

            foreach(string input in data)
                Bytes.Add(new ByteMem(input));

            GenerateMap();
            Print();
        }

        #region private methods
        private void GenerateMap()
        {
            for (int y = 0; y < Range + 1; y++)
                for (int x = 0; x < Range + 1; x++)
                    Map[y, x] = '.';

            for (int i = 0; i < NbOfDrop; i++)
                Map[Bytes[i].Y, Bytes[i].X] = '#';
        }

        private void Print()
        {
            Console.WriteLine("--------------------");
            for (int y = 0; y < Range + 1; y++)
            {
                for (int x = 0; x < Range + 1; x++)
                    Console.Write(Map[y, x]);
                Console.WriteLine();
            }
            Console.WriteLine("--------------------");
        }


        internal (int, int) FindBlockCoord()
        {
            int index = 0;
            foreach (ByteMem bit in Bytes)
            {
                index++;
                Console.WriteLine($"Testing bit n '{index}' / {Bytes.Count}");

                if (Map[bit.Y, bit.X] == '#')
                    continue;
                else
                {
                    Map[bit.Y, bit.X] = '#';

                    if (IsBlocked())
                        return (bit.Y, bit.X);
                    else
                        GenerateMap();
                }
            }
            throw new Exception("No block found.");
        }


        public bool IsBlocked()
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
                    Map[path.Item1, path.Item2] = 'S';
                    LookAround(path, 'S').ForEach(p => availablePathsStart.Add(p));
                }

                foreach ((int, int) path in pathsEnd)
                {
                    Map[path.Item1, path.Item2] = 'E';
                    LookAround(path, 'E').ForEach(p => availablePathsEnd.Add(p));
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

        private List<(int, int)> LookAround((int, int) coords, char obstacle)
        {
            List<(int, int)> availablePaths = [];

            // look left
            try
            {
                if (Map[coords.Item1, coords.Item2 - 1] != '#' && Map[coords.Item1, coords.Item2 - 1] != obstacle)
                    availablePaths.Add((coords.Item1, coords.Item2 - 1));

            }
            catch { }

            // look right
            try
            {
                if (Map[coords.Item1, coords.Item2 + 1] != '#' && Map[coords.Item1, coords.Item2 + 1] != obstacle)
                    availablePaths.Add((coords.Item1, coords.Item2 + 1));

            }
            catch
            {

            }

            // look up
            try
            {

                if (Map[coords.Item1 - 1, coords.Item2] != '#' && Map[coords.Item1 - 1, coords.Item2] != obstacle)
                    availablePaths.Add((coords.Item1 - 1, coords.Item2));
            }
            catch
            {

            }

            // look down
            try
            {

                if (Map[coords.Item1 + 1, coords.Item2] != '#' && Map[coords.Item1 + 1, coords.Item2] != obstacle)
                    availablePaths.Add((coords.Item1 + 1, coords.Item2));
            }
            catch
            {

            }

            return availablePaths;
        }

        #endregion
    }
}
