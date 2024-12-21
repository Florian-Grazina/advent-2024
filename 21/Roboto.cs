namespace _21
{
    internal class Roboto : IControllable
    {
        public (int, int) ArmCoords { get; set; }
        public HashSet<char> Map { get; set; }

        public List<Direction> Input { get; set; }
        public List<char> Output { get; set; }

        public Roboto(Roboto controlledBy)
        {
            Map = GenerateMap();
        }

        public void MoveDown()
        {
            ArmCoords = (ArmCoords.Item1 + 1, ArmCoords.Item2);
            Input.Add(Direction.DOWN);
        }

        public void MoveLeft()
        {
            ArmCoords = (ArmCoords.Item1, ArmCoords.Item2 - 1);
            Input.Add(Direction.LEFT);
        }

        public void MoveRight()
        {
            ArmCoords = (ArmCoords.Item1, ArmCoords.Item2 + 1);
            Input.Add(Direction.RIGHT);
        }

        public void MoveUp()
        {
            ArmCoords = (ArmCoords.Item1 - 1, ArmCoords.Item2);
            Input.Add(Direction.UP);
        }

        public void Press()
        {

        }


        private HashSet<char> GenerateMap()
        {
            HashSet<char> map = [];

            map.Add('.');
            map.Add('0');
            map.Add('A');

            map.Add('1');
            map.Add('2');
            map.Add('3');

            map.Add('4');
            map.Add('5');
            map.Add('6');

            map.Add('7');
            map.Add('8');
            map.Add('9');

            return map;
        }
    }
}
