using _16;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new(input);
mapHolder.Reindeer.Run();

long result = Database.GetScore();
Console.WriteLine(result);