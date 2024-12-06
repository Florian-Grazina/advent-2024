namespace _06
{
    internal class Guard
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public int XOrigin { get; set; }
        public int YOrigin { get; set; }
        public Direction DirectionOrigin { get; set; }


        public Guard(int y, int x, char icon)
        {
            X = x;
            Y = y;
            Direction = SetGuardDirection(icon);

            XOrigin = x;
            YOrigin = y;
            DirectionOrigin = Direction;
        }

        public void RollBack()
        {
            X = XOrigin;
            Y = YOrigin;
            Direction = DirectionOrigin;
        }

        public (int, int) GetPosition()
        {
            return (Y, X);
        }

        public (int, int) GetPositionAfterTurn()
        {
            return Direction switch
            {
                Direction.Up => (Y, X + 1),
                Direction.Down => (Y, X - 1),
                Direction.Left => (Y + 1, X),
                Direction.Right => (Y - 1, X),
                _ => throw new Exception("Invalid direction")
            };
        }

        public Direction GetDirectionAfterTurn()
        {
            return Direction switch
            {
                Direction.Up => Direction.Right,
                Direction.Right => Direction.Down,
                Direction.Down => Direction.Left,
                Direction.Left => Direction.Up,
                _ => throw new Exception("Invalid direction")
            };
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
