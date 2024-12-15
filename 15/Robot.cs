namespace _15
{
    internal class Robot : Movable
    {
        public Stack<Direction> Directions { get; set; }

        public Robot(string data)
        {
            Directions = [];
            ParseData(data.Replace("\r\n", null));
        }

        private void ParseData(string data)
        {
            for (int i = data.Length - 1; i >= 0; i--)
            {
                Directions.Push(data[i] switch
                {
                    '^' => Direction.UP,
                    'v' => Direction.DOWN,
                    '<' => Direction.LEFT,
                    '>' => Direction.RIGHT,
                    _ => throw new Exception("Invalid direction")
                });
            }
        }
    }
}
