namespace _18
{
    internal class ByteMem
    {
        public (int, int) Coords { get; set; }
        public int Y => Coords.Item1;
        public int X => Coords.Item2;

        public ByteMem(string data)
        {
            string[] dataArray = data.Split(',');
            Coords = (int.Parse(dataArray[1]), int.Parse(dataArray[0]));
        }
    }
}
