
namespace _15
{
    internal abstract class Movable
    {
        public (int, int) Coords { get; set; }
        public int Y => Coords.Item1;
        public int X => Coords.Item2;

        public void Move(Direction direction)
        {
            (int, int) coords = direction switch
            {
                Direction.UP => (Coords.Item1 - 1, Coords.Item2),
                Direction.DOWN => (Coords.Item1 + 1, Coords.Item2),
                Direction.LEFT => (Coords.Item1, Coords.Item2 - 1),
                Direction.RIGHT => (Coords.Item1, Coords.Item2 + 1),
                _ => throw new NotImplementedException(),
            };

            Coords = coords;
        }
    }
}
