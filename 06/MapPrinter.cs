namespace _06
{
    internal static class MapPrinter
    {
        public static void Print(char[,] map, Dictionary<(int, int), List<Direction>> coordsDico)
        {
            Console.WriteLine("*********************************");

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (coordsDico.TryGetValue((y, x), out var dirs))
                    {
                        if (dirs.Count > 1)
                            Console.Write("+");
                        else if (dirs.First() == Direction.Left || dirs.First() == Direction.Right)
                            Console.Write("-");
                        else
                            Console.Write("|");
                    }
                    else
                        Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("*********************************");
        }
    }
}
