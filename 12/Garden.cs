namespace _12
{
    internal class Garden
    {
        public Dictionary<(int, int), char> LandDico;

        public char Id { get; set; }
        public int Area { get; set; }
        public int Perimeter { get; set; }

        public int Price => Area * Perimeter;


        public Garden(char id, (int, int) coords)
        {
            Id = id;
            LandDico = [];
            TryAddLand(coords);
        }

        public bool TryAddLand((int, int) coords)
        {
            return LandDico.TryAdd(coords, Id);
        }

        public void CalculateData(char[,] map)
        {
            Area = LandDico.Count;

            foreach (var item in LandDico)
            {
                if (GetLandDirection(map, item.Key, Direction.UP) == '#')
                    Perimeter++;
                if (GetLandDirection(map, item.Key, Direction.DOWN) == '#')
                    Perimeter++;
                if (GetLandDirection(map, item.Key, Direction.RIGHT) == '#')
                    Perimeter++;
                if (GetLandDirection(map, item.Key, Direction.LEFT) == '#')
                    Perimeter++;
            }
        }

        public char GetLandDirection(char[,] map, (int, int) coords, Direction dir)
        {
            // check up
            (int, int) up = dir switch
            {
                Direction.UP => (coords.Item1 - 1, coords.Item2),
                Direction.DOWN => (coords.Item1 + 1, coords.Item2),
                Direction.LEFT => (coords.Item1, coords.Item2 - 1),
                Direction.RIGHT => (coords.Item1, coords.Item2 + 1),
                _ => throw new Exception("diretion")
            };

            if (!CoordsAreInbound(up, map) || map[up.Item1, up.Item2] != Id)
                return '#';

            return map[coords.Item1, coords.Item2];
        }

        public bool CoordsAreInbound((int, int) coords, char[,] map)
        {
            bool isInBound = coords.Item1 >= 0 && coords.Item1 < map.GetLength(0) && coords.Item2 >= 0 && coords.Item2 < map.GetLength(1);
            return isInBound;
        }
    }

    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
}
