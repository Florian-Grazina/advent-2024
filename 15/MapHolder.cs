namespace _15
{
    internal class MapHolder
    {
        public char[,] Map { get; set; }
        public Robot Robot { get; set; }
        public List<Box> Boxes { get; set; }

        public MapHolder(string data, Robot robot)
        {
            Boxes = [];
            Robot = robot;
            Map = ParseData(data.Split("\r\n"));
            Print();
        }

        public int Run()
        {
            while (Robot.Directions.Count > 0)
            {
                Direction direction = Robot.Directions.Pop();
                if (CanMove(Robot, direction))
                    Robot.Move(direction);

                UpdateMap();
                //Print();
            }

            return Boxes.Sum(b => b.GetGpsCoords);
        }

        private void UpdateMap()
        {
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    if (Map[y, x] == '.' || Map[y, x] == '#')
                        continue;
                    Map[y, x] = '.';
                }
            }

            Map[Robot.Y, Robot.X] = '@';

            foreach (var box in Boxes)
                Map[box.Y, box.X] = 'O';
        }

        public void Print()
        {
            Console.WriteLine("********************************************");
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Console.Write(Map[y, x]);
                }
                Console.WriteLine();
            }
        }

        private bool CanMove(Movable movable, Direction dir)
        {
            (int, int) coords = dir switch
            {
                Direction.UP => (movable.Y - 1, movable.X),
                Direction.DOWN => (movable.Y + 1, movable.X),
                Direction.LEFT => (movable.Y, movable.X - 1),
                Direction.RIGHT => (movable.Y, movable.X + 1),
                _ => throw new NotImplementedException(),
            };

            if (Map[coords.Item1, coords.Item2] == '#')
                return false;

            else
            {
                Box? box = Boxes.FirstOrDefault(b => b.Coords == coords);
                if (box != null)
                {
                    if (CanMove(box, dir))
                    {
                        box.Move(dir);
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }

        private char[,] ParseData(string[] data)
        {
            char[,] map = new char[data.Length, data[0].Length * 2];

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x += 2)
                {
                    char input = data[y][x];

                    if (input == '@')
                    {
                        Robot.Coords = (y, x);
                        map[y, x] = '@';
                        map[y, x + 1] = '.';
                    }

                    else if (input == 'O')
                    {
                        Boxes.Add(new Box((y, x)));
                        map[y, x] = '[';
                        map[y , x + 1] = ']';
                    }

                    else if (input == '#')
                    {
                        map[y, x] = '#';
                        map[y, x + 1] = '#';
                    }

                    else if (input == '.')
                    {
                        map[y, x] = '.';
                        map[y, x + 1] = '.';
                    }
                }
            }
            return map;
        }
    }
}
