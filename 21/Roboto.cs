

namespace _21
{
    internal class Roboto : IControllable
    {
        public (int, int) ArmCoords { get; set; }
        public Dictionary<char, (int, int)> Map { get; set; }

        public List<List<char>> Outputs = [];

        public Roboto(string[] data)
        {
            foreach(string input in data)
                Outputs.Add(GetList(input));

            Map = GenerateMap();
            ArmCoords = Map['A'];
        }

        public List<Direction> GetInput()
        {
            List<Direction> input = [];

            foreach(List<char> ouput in Outputs)
            {
                foreach (char data in ouput)
                    input.AddRange(GetDirectionsByCoords(Map[data]));
            }

            return input;
        }

        private List<char> GetList(string input)
        {
            List<char> list = [];

            foreach (char c in input)
                list.Add(c);
            return list;
        }

        public Direction MoveDown()
        {
            ArmCoords = (ArmCoords.Item1 + 1, ArmCoords.Item2);
            return Direction.DOWN;
        }

        public Direction MoveLeft()
        {
            ArmCoords = (ArmCoords.Item1, ArmCoords.Item2 - 1);
            return Direction.LEFT;
        }

        public Direction MoveRight()
        {
            ArmCoords = (ArmCoords.Item1, ArmCoords.Item2 + 1);
            return Direction.RIGHT;
        }

        public Direction MoveUp()
        {
            ArmCoords = (ArmCoords.Item1 - 1, ArmCoords.Item2);
            return Direction.UP;
        }

        public Direction Press()
        {
            return Direction.PRESS;
        }


        private List<Direction> GetDirectionsByCoords((int, int) value)
        {
            List<Direction> directions = [];

            int deltaY = value.Item1 - ArmCoords.Item1;
            int deltaX = value.Item2 - ArmCoords.Item2;

            while(deltaX != 0)
            {
                if (deltaX > 0)
                {
                    directions.Add(MoveRight());
                    deltaX--;
                }
                else
                {
                    directions.Add(MoveLeft());
                    deltaX++;
                }
            }

            while (deltaY != 0)
            {
                if (deltaY > 0)
                {
                    directions.Add(MoveDown());
                    deltaY--;
                }
                else
                {
                    directions.Add(MoveUp());
                    deltaY++;
                }
            }

            directions.Add(Press());
            directions = [.. directions.OrderBy(d => d != Direction.RIGHT && d != Direction.UP)];

            return directions;
        }


        private Dictionary<char, (int, int)> GenerateMap()
        {
            Dictionary<char, (int, int)> map = [];

            map.Add('0', (3, 1));
            map.Add('A', (3, 2));

            map.Add('1', (2, 0));
            map.Add('2', (2, 1));
            map.Add('3', (2, 2));

            map.Add('4', (1, 0));
            map.Add('5', (1, 1));
            map.Add('6', (1, 2));

            map.Add('7', (0, 0));
            map.Add('8', (0, 1));
            map.Add('9', (0, 2));

            return map;
        }
    }
}
