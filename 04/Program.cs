using _04;

string[] input = File.ReadAllLines("../../../input.txt");

char[,] map = new char[input.Length, input[0].Length];

for(int y = 0; y < input.Length; y++)
    for (int x = 0; x < input[y].Length; x++)
        map[y, x] = input[y][x];

int result = 0;

for (int y = 0; y < map.GetLength(0); y++)
{
    for(int x = 0; x < map.GetLength(1); x++)
    {
        result += Resolver.GetResult(map, y, x);
    }
}