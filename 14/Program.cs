using _14;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new(input);
mapHolder.Run();
Console.WriteLine(mapHolder.GetQuadrantsResult());