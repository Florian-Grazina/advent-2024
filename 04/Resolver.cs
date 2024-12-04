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
            if (map[y, x] != 'X')
                return 0;

            int result = 0;

            List<Direction> directions = GetDirections(map, y, x);
            foreach(Direction direction in directions)
            {
                result += GetXMASResult(map, y, x, direction);
            }

            return result;
        }

        private List<Direction> GetDirections(char[,] map, int y, int x)
        {
            List<Direction> directions = [];

            foreach(var direction in directionDico)
            {
                try
                {
                    if (map[y + direction.Value.Item1, x + direction.Value.Item2] == 'M')
                        directions.Add(direction.Key);
                }
                catch
                {

                }
            }
            return directions;
        }

        private int GetXMASResult(char[,] map, int y, int x, Direction direction)
        {
            try
            {
                var directionValue = directionDico[direction];

                GetNewCoords(ref y, ref x, direction);
                if (map[y, x] != 'M')
                    return 0;

                GetNewCoords(ref y, ref x, direction);
                if (map[y, x] != 'A')
                    return 0;

                GetNewCoords(ref y, ref x, direction);
                if (map[y, x] == 'S')
                    return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private void GetNewCoords(ref int y, ref int x, Direction direction)
        {
            var directionValue = directionDico[direction];
            y += directionValue.Item1;
            x += directionValue.Item2;
        }
    }
}
