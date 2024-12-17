using _16;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new(input);
mapHolder.Reindeer.Run();

Console.WriteLine(Database.Score);

var ok = Database.Paths;

Console.WriteLine("");
// 80 000 too low

// 150 000 too high