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

        public int GetQuadrantsResult()
        {
            Dictionary<short, List<Robot>> robotDico = new()
            {
                { 1, []},
                { 2, []},
                { 3, []},
                { 4, []}
            };

            int middleX = (MapBound.Item2 - 1) / 2;
            int middleY = (MapBound.Item1 - 1) / 2;

            Dictionary<short, Range> quandrantsDico = new()
            {
                {1, new(0, middleY - 1, 0, middleX - 1) },
                {2, new(0, middleY - 1, middleX + 1, MapBound.Item2 - 1) },
                {3, new(middleY + 1, MapBound.Item1 - 1, 0, middleX - 1) },
                {4, new(middleY + 1, MapBound.Item1 - 1, middleX + 1, MapBound.Item2 - 1) }
            };

            foreach (Robot robot in Robots)
            {
                short id = robot.GetQuadrantId(quandrantsDico);
                if (id == 0)
                    continue;

                robotDico[id].Add(robot);
            }

            //return robotDico.Values.Aggregate((a, b) => a * b);
            return 0;
        }

        private void MoveRobots(int numberOfMoves)
        {
            for (int i = 0; i < numberOfMoves; i++)
                foreach (Robot robot in Robots)
                    robot.Move();

            foreach (Robot robot in Robots)
            {
                int y = robot.Coords.Item1;
                int x = robot.Coords.Item2;

                y = y % MapBound.Item1;
                y = y < 0 ? MapBound.Item1 + y : y;

                x = x % MapBound.Item2;
                x = x < 0 ? MapBound.Item2 + x : x;

                robot.Coords = (y, x);
            }
        }
    }
}
