namespace _15
{
    internal class Box : Movable
    {
        public int GetGpsCoords => Coords.Item1 * 100 + Coords.Item2;

        public Box((int, int) coords)
        {
            Coords = coords;
        }
    }
}
