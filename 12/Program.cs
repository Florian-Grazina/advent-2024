using _12;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new(input);
mapHolder.FindGarden();
Console.WriteLine(mapHolder.Gardens.Sum(g => g.Price));