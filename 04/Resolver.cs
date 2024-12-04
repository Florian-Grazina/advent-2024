namespace _04
{
    internal enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
        None
    }

    internal class Resolver
    {
        private Dictionary<Direction, Tuple<int, int>> directionDico = [];

        public Resolver()
        {
            directionDico.Add(Direction.Up, new Tuple<int, int>(-1, 0));
            directionDico.Add(Direction.Down, new Tuple<int, int>(1, 0));
            directionDico.Add(Direction.Left, new Tuple<int, int>(0, -1));
            directionDico.Add(Direction.Right, new Tuple<int, int>(0, 1));
            directionDico.Add(Direction.UpLeft, new Tuple<int, int>(-1, -1));
            directionDico.Add(Direction.UpRight, new Tuple<int, int>(-1, 1));
            directionDico.Add(Direction.DownLeft, new Tuple<int, int>(1, -1));
            directionDico.Add(Direction.DownRight, new Tuple<int, int>(1, 1));
        }

        public int GetResult(char[,] map, int y, int x)
        {
            if (map[y, x] != 'A')
                return 0;

            if (GetXMASResult(map, y, x, Direction.UpLeft, Direction.DownRight))
                if (GetXMASResult(map, y, x, Direction.DownLeft, Direction.UpRight))
                    return 1;

            return 0;
        }

        private bool GetXMASResult(char[,] map, int y, int x, Direction direction1, Direction direction2)
        {
            try
            {
                List<char> result = [];

                Tuple<int, int> coords1 = GetNewCoords(y, x, direction1);
                Tuple<int, int> coords2 = GetNewCoords(y, x, direction2);

                result.Add(map[coords1.Item1, coords1.Item2]);
                result.Add(map[coords2.Item1, coords2.Item2]);

                if (result.Contains('M') && result.Contains('S'))
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        private Tuple<int, int> GetNewCoords(int y, int x, Direction direction)
        {
            var directionValue = directionDico[direction];
            y += directionValue.Item1;
            x += directionValue.Item2;

            return new Tuple<int, int>(y, x);
        }
    }
}
