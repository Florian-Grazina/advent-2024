namespace _12
{
    internal class Garden
    {
        public Dictionary<(int, int), char> LandDico;

        public char Id { get; set; }
        public int Area { get; set; }
        public int Perimeter { get; set; }
        public int NbOfAngles { get; set; }

        public int Price => Area * NbOfAngles;


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
                bool hasBoundUp = GetLandDirection(map, item.Key, Direction.UP) == '#';
                bool hasBoundRight = GetLandDirection(map, item.Key, Direction.RIGHT) == '#';
                bool hasBoundDown = GetLandDirection(map, item.Key, Direction.DOWN) == '#';
                bool hasBoundLeft = GetLandDirection(map, item.Key, Direction.LEFT) == '#';

                if (hasBoundUp && hasBoundRight)
                    NbOfAngles++;
                if (hasBoundRight && hasBoundDown)
                    NbOfAngles++;
                if (hasBoundDown && hasBoundLeft)
                    NbOfAngles++;
                if (hasBoundLeft && hasBoundUp)
                    NbOfAngles++;

                bool hasSameIdUp = GetLandDirection(map, item.Key, Direction.UP) == Id;
                bool hasSameIdRight = GetLandDirection(map, item.Key, Direction.RIGHT) == Id;
                bool hasSameIdDown = GetLandDirection(map, item.Key, Direction.DOWN) == Id;
                bool hasSameIdLeft = GetLandDirection(map, item.Key, Direction.LEFT) == Id;

                if (hasSameIdUp && hasSameIdRight)
                {
                    (int, int) coordsToCheck = (item.Key.Item1 - 1, item.Key.Item2 + 1);
                    if (CoordsAreInbound(coordsToCheck, map) && map[coordsToCheck.Item1, coordsToCheck.Item2] != Id)
                        NbOfAngles++;
                }

                if (hasSameIdUp && hasSameIdLeft)
                {
                    (int, int) coordsToCheck = (item.Key.Item1 - 1, item.Key.Item2 - 1);
                    if (CoordsAreInbound(coordsToCheck, map) && map[coordsToCheck.Item1, coordsToCheck.Item2] != Id)
                        NbOfAngles++;
                }

                if (hasSameIdDown && hasSameIdLeft)
                {
                    (int, int) coordsToCheck = (item.Key.Item1 + 1, item.Key.Item2 - 1);
                    if (CoordsAreInbound(coordsToCheck, map) && map[coordsToCheck.Item1, coordsToCheck.Item2] != Id)
                        NbOfAngles++;
                }

                if (hasSameIdDown && hasSameIdRight)
                {
                    (int, int) coordsToCheck = (item.Key.Item1 + 1, item.Key.Item2 + 1);
                    if (CoordsAreInbound(coordsToCheck, map) && map[coordsToCheck.Item1, coordsToCheck.Item2] != Id)
                        NbOfAngles++;
                }
            }
        }

        private bool CheckInnerAngle(char[,] map, (int, int) key)
        {
            throw new NotImplementedException();
        }

        public char GetLandDirection(char[,] map, (int, int) coords, Direction dir)
        {
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
