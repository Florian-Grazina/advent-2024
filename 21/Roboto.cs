namespace _21
{
    internal class Roboto : IControllable
    {
        public (int, int) ArmCoords { get; set; }


        public List<char> GetInput(Dictionary<char, (int, int)> map, List<char> output, bool isKeyPad)
        {
            ArmCoords = map['A'];

            List<char> input = [];

            foreach (char data in output)
                input.AddRange(GetDirectionsByCoords(map[data], isKeyPad));

            return input;
        }
     
        public char MoveDown()
        {
            ArmCoords = (ArmCoords.Item1 + 1, ArmCoords.Item2);
            return 'v';
        }

        public char MoveLeft()
        {
            ArmCoords = (ArmCoords.Item1, ArmCoords.Item2 - 1);
            return '<';
        }

        public char MoveRight()
        {
            ArmCoords = (ArmCoords.Item1, ArmCoords.Item2 + 1);
            return '>';
        }

        public char MoveUp()
        {
            ArmCoords = (ArmCoords.Item1 - 1, ArmCoords.Item2);
            return '^';
        }

        public char Press()
        {
            return 'A';
        }

        private List<char> GetDirectionsByCoords((int, int) value, bool isKeyPad)
        {
            List<char> directions = [];

            int deltaY = value.Item1 - ArmCoords.Item1;
            int deltaX = value.Item2 - ArmCoords.Item2;

            while (deltaX != 0)
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

            //if (isKeyPad)
            //    directions = [.. directions.OrderBy(d => d != '>' && d != '^')];
            //else
            //    directions = [.. directions.OrderBy(d => d != '>' && d != 'v')];

            ReplacePattern(directions);

            return directions;
        }

        static void ReplacePattern(List<char> charList)
        {
            for (int i = 0; i < charList.Count - 2; i++)
            {
                if (charList[i] == '^' && charList[i + 1] == '<' && charList[i + 2] == 'A')
                {
                    charList[i] = '<';
                    charList[i + 1] = '^';
                    charList[i + 2] = 'A';
                }

                if (charList[i] == 'v' && charList[i + 1] == '<' && charList[i + 2] == 'A')
                {
                    charList[i] = '<';
                    charList[i + 1] = 'v';
                    charList[i + 2] = 'A';
                }
            }
        }
    }
}
