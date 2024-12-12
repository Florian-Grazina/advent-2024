namespace _12
{
    internal class MapHolder
    {
        public List<Garden> Gardens { get; set; }
        public char[,] Map { get; set; }

        public MapHolder(string[] data)
        {
            Map = ParseData(data);
            Gardens = new();
        }

        private char[,] ParseData(string[] data)
        {
            char[,] map = new char[data.Length, data[0].Length];

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    map[y, x] = data[y][x];
                }
            }
            return map;
        }

        public void FindGarden()
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    if(Map[y, x] == '#')
                        continue;

                    else
                    {
                        Garden garden = new(Map[y, x], (y , x));
                        FindGardenRecursive(garden, (y, x));
                        garden.CalculateData(Map);
                        ReplaceMapTiles(garden);
                        Gardens.Add(garden);
                    }
                }
            }
        }

        private void FindGardenRecursive(Garden garden, (int, int) coords)
        {
            // check up
            (int, int) up = (coords.Item1 - 1, coords.Item2);
            if (CoordsAreInbound(up) && Map[up.Item1, up.Item2] == garden.Id)
            {
                if(garden.TryAddLand(up))
                    FindGardenRecursive(garden, up);
            }

            // check down
            (int, int) down = (coords.Item1 + 1, coords.Item2);
            if (CoordsAreInbound(down) && Map[down.Item1, down.Item2] == garden.Id)
            {
                if (garden.TryAddLand(down))
                    FindGardenRecursive(garden, down);
            }

            // check left
            (int, int) left = (coords.Item1, coords.Item2 - 1);
            if (CoordsAreInbound(left) && Map[left.Item1, left.Item2] == garden.Id)
            {
                if (garden.TryAddLand(left))
                    FindGardenRecursive(garden, left);
            }

            // check right
            (int, int) right = (coords.Item1, coords.Item2 + 1);
            if (CoordsAreInbound(right) && Map[right.Item1, right.Item2] == garden.Id)
            {
                if (garden.TryAddLand(right))
                    FindGardenRecursive(garden, right);
            }
        }

        private bool CoordsAreInbound((int, int) coords)
        {
            bool isInBound = coords.Item1 >= 0 && coords.Item1 < Map.GetLength(0) && coords.Item2 >= 0 && coords.Item2 < Map.GetLength(1);
            return isInBound;
        }

        private void ReplaceMapTiles(Garden garden)
        {
            foreach (var land in garden.LandDico)
            {
                Map[land.Key.Item1, land.Key.Item2] = '#';
            }
        }
    }
}
