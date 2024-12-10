
namespace _10
{
    internal class TrailHead
    {
        public (int, int) Coords { get; set; }
        public List<(int, int)> AvailablePaths { get; set; }
        public int Result { get; set; }


        public TrailHead((int, int) coords)
        {
            AvailablePaths = [];
            Coords = coords;
        }

        public int GetScore(int[,] map)
        {
            GetAllPath(map, Coords, 1);
            return AvailablePaths.Count;
        }

        private void GetAllPath(int[,] map, (int, int) coords, int indexToFind)
        {
            List<(int, int)> availablePaths = LookAround(map, coords, indexToFind);

            if (indexToFind == 9)
            {
                availablePaths.ForEach(p => AvailablePaths.Add(p));
                return;
            }

            else
            {
                foreach (var path in availablePaths)
                {
                    GetAllPath(map, path, indexToFind + 1);
                }
            }
        }

        private List<(int, int)> LookAround(int[,] map, (int, int) coords, int indexToFind)
        {
            List<(int, int)> availablePaths = [];

            // look left
            if (coords.Item2 != 0)
                if (map[coords.Item1, coords.Item2 - 1] == indexToFind)
                    availablePaths.Add((coords.Item1, coords.Item2 - 1));

            // look right
            if (coords.Item2 != map.GetLength(1) - 1)
                if (map[coords.Item1, coords.Item2 + 1] == indexToFind)
                    availablePaths.Add((coords.Item1, coords.Item2 + 1));

            // look up
            if (coords.Item1 != 0)
                if (map[coords.Item1 - 1, coords.Item2] == indexToFind)
                    availablePaths.Add((coords.Item1 - 1, coords.Item2));

            // look down
            if (coords.Item1 != map.GetLength(0) - 1)
                if (map[coords.Item1 + 1, coords.Item2] == indexToFind)
                    availablePaths.Add((coords.Item1 + 1, coords.Item2));

            return availablePaths;
        }
    }
}
