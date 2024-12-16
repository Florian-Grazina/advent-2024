
namespace _14
{
    internal class MapHolder
    {
        public List<Robot> Robots { get; set; }
        public (int, int) MapBound { get; set; }
        public int NbMax { get; set; }
        public int NbOfSec { get; set; }

        public MapHolder(string[] data)
        {
            MapBound = (103, 101);

            Robots = new();
            foreach (string line in data)
                Robots.Add(new Robot(line));
        }

        public void Run()
        {
            MoveRobots(10000);
        }

        public void Print()
        {
            Console.WriteLine("********************************************");
            for (int y = 0; y < MapBound.Item1; y++)
            {
                for (int x = 0; x < MapBound.Item2; x++)
                {
                    int count = Robots.Count(r => r.Coords.Item1 == y && r.Coords.Item2 == x);
                    if (count > 0)
                        Console.Write(count);
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private void MoveRobots(int numberOfMoves)
        {
            for (int i = 0; i < numberOfMoves; i++)
            {
                Console.WriteLine(i);

                foreach (Robot robot in Robots)
                {
                    robot.Move(MapBound);
                    int y = robot.Coords.Item1;
                    int x = robot.Coords.Item2;

                    y = y % MapBound.Item1;
                    y = y < 0 ? MapBound.Item1 + y : y;

                    x = x % MapBound.Item2;
                    x = x < 0 ? MapBound.Item2 + x : x;

                    robot.Coords = (y, x);
                }

                if (i == 8269)
                    Print();

                GetMaxNum(i);
            }
        }

        private void GetMaxNum(int numberOfMoves)
        {
            int num = 0;

            foreach (Robot robot in Robots)
            {
                //look up
                if (HasNeighboor(robot.Y - 1, robot.X))
                    num++;
                //look down
                if (HasNeighboor(robot.Y + 1, robot.X))
                    num++;
                //look right
                if (HasNeighboor(robot.Y, robot.X + 1))
                    num++;
                //look left
                if (HasNeighboor(robot.Y, robot.X - 1))
                    num++;
            }

            if(num > NbMax)
            {
                Print();
                NbMax = num;
                NbOfSec = numberOfMoves;
            }
        }

        private bool HasNeighboor(int y, int x)
        {
            if (Robots.Any(r => r.Y == y && r.X == x))
                return true;
            return false;
        }
    }
}
