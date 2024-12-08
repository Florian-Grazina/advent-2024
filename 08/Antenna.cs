namespace _08
{
    internal class Antenna
    {
        public (int, int) Coords { get; set; }
        public char Frenquency { get; set; } = default!;

        public Antenna((int, int) coords, char frenquency)
        {
            Coords = coords;
            Frenquency = frenquency;
        }
    }
}
