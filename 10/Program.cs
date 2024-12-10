using _10;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new MapHolder(input);
int result = mapHolder.GetScore();
Console.WriteLine(result);