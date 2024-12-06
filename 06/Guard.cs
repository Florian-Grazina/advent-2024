namespace _06
{
    internal class Guard
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }


        public Guard(int y, int x, char icon)
        {
            X = x;
            Y = y;
            Direction = SetGuardDirection(icon);
        }

        public (int, int) GetPosition()
        {
            return (Y, X);
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Down:
                    Y++;
                    break;
                case Direction.Left:
                    X--;
                    break;
                case Direction.Right:
                    X++;
                    break;
            }
        }

        public void MoveBack()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Y++;
                    break;
                case Direction.Down:
                    Y--;
                    break;
                case Direction.Left:
                    X++;
                    break;
                case Direction.Right:
                    X--;
                    break;
            }
        }

        public void MoveBackAndTurn()
        {
            MoveBack();
            Turn();
        }

        private Direction SetGuardDirection(char v)
        {
            return v switch
            {
                'v' => Direction.Down,
                '^' => Direction.Up,
                '<' => Direction.Left,
                '>' => Direction.Right,
                _ => throw new Exception("Invalid guard direction")
            };
        }

        private void Turn()
        {
            Direction = Direction switch
            {
                Direction.Up => Direction.Right,
                Direction.Right => Direction.Down,
                Direction.Down => Direction.Left,
                Direction.Left => Direction.Up,
                _ => throw new Exception("Invalid direction")
            };
        }

    }
}
