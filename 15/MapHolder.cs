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
            int index = 0;
            while (Robot.Directions.Count > 0)
            {
                index++;

                Direction direction = Robot.Directions.Pop();
                if (CanMove(Robot, direction))
                    Robot.Move(direction);

                UpdateMap();
                //Print();
                Console.WriteLine(index);
                //Console.WriteLine(direction);
            }

            return Boxes.Sum(b => b.GetGpsCoords);
        }

        private void UpdateMap()
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    if (Map[y, x] == '.' || Map[y, x] == '#')
                        continue;
                    Map[y, x] = '.';
                }
            }

            Map[Robot.Y, Robot.X] = '@';

            foreach (var box in Boxes)
            {
                Map[box.Y, box.X] = '[';
                Map[box.Y, box.X + 1] = ']';
            }
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

            if (movable is Box && Map[coords.Item1, coords.Item2 + 1] == '#')
                return false;

            else
            {
                if (movable is Robot)
                {
                    Box? box = null;
                    if (Map[coords.Item1, coords.Item2] == '[')
                        box = Boxes.First(b => b.Coords == coords);

                    else if (Map[coords.Item1, coords.Item2] == ']')
                        box = Boxes.First(b => b.Coords == (coords.Item1, coords.Item2 - 1));

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

                else if (movable is Box && dir == Direction.RIGHT || dir == Direction.LEFT)
                {
                    if (dir == Direction.RIGHT)
                        coords = (coords.Item1, coords.Item2 + 1);

                    Box? box = null;
                    if (Map[coords.Item1, coords.Item2] == '[')
                        box = Boxes.First(b => b.Coords == coords);

                    else if (Map[coords.Item1, coords.Item2] == ']')
                        box = Boxes.First(b => b.Coords == (coords.Item1, coords.Item2 - 1));

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

                else if (movable is Box)
                {
                    List<Box> boxes = [];

                    if (Map[coords.Item1, coords.Item2] == '[')
                    {
                        Box box = Boxes.First(b => b.Coords == coords);
                        if (box != null)
                            boxes.Add(box);
                    }

                    if (Map[coords.Item1, coords.Item2] == ']')
                    {
                        Box box = Boxes.First(b => b.Coords == (coords.Item1, coords.Item2 - 1));
                        if (box != null)
                            boxes.Add(box);
                    }

                    if (Map[coords.Item1, coords.Item2 + 1] == '[')
                    {
                        Box box = Boxes.First(b => b.Coords == (coords.Item1, coords.Item2 + 1));
                        if (box != null)
                            boxes.Add(box);
                    }

                    //if (Map[coords.Item1, coords.Item2 + 1] == ']')
                    //{
                    //    Box box = Boxes.First(b => b.Coords == (coords.Item1, coords.Item2));
                    //    if (box != null)
                    //        boxes.Add(box);
                    //}

                    if (boxes.Count > 0)
                    {
                        bool canMove = true;
                        foreach (Box box in boxes)
                        {
                            if (!CanMove(box, dir))
                            {
                                canMove = false;
                                break;
                            }
                        }

                        if (canMove)
                        {
                            foreach (Box box in boxes)
                                box.Move(dir);
                            return true;
                        }
                        return false;
                    }
                }

            }
            return true;
        }

        private char[,] ParseData(string[] data)
        {
            char[,] map = new char[data.Length, data[0].Length * 2];

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[0].Length; x++)
                {
                    char input = data[y][x];

                    int newX = x * 2;

                    if (input == '@')
                    {
                        Robot.Coords = (y, newX);
                        map[y, newX] = '@';
                        map[y, newX + 1] = '.';
                    }

                    else if (input == 'O')
                    {
                        Boxes.Add(new Box((y, newX)));
                        map[y, newX] = '[';
                        map[y, newX + 1] = ']';
                    }

                    else if (input == '#')
                    {
                        map[y, newX] = '#';
                        map[y, newX + 1] = '#';
                    }

                    else if (input == '.')
                    {
                        map[y, newX] = '.';
                        map[y, newX + 1] = '.';
                    }
                }
            }
            return map;
        }
    }
}
