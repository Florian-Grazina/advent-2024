namespace _14
{
    internal class MapHolder
    {
        public List<Robot> Robots { get; set; }
        public (int, int) MapBound { get; set; }

        public MapHolder(string[] data)
        {
            MapBound = (7, 11);

            Robots = new();
            foreach (string line in data)
                Robots.Add(new Robot(line));
        }

        public void Run()
        {
            MoveRobots(100);
        }

        private void MoveRobots(int numberOfMoves)
        {
            for (int i = 0; i < numberOfMoves; i++)
                foreach (Robot robot in Robots)
                    robot.Move();

            foreach(Robot robot in Robots)
            {
                int y = robot.Coords.Item1;
                int x = robot.Coords.Item2;

                y = y % MapBound.Item1;
                x = x % MapBound.Item2;


                robot.Coords = (y, x);
            }
        }
    }
}
