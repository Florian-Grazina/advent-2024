using _20;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new MapHolder(input);

List<IGrouping<int, int>> ok = mapHolder.Cheats.Select(c => c.Score).OrderBy(c => c).GroupBy(c => c).ToList();

foreach (IGrouping<int, int> group in ok)
{
    Console.WriteLine($"{group.Count()} cheats that saves {group.Key} picoseconds");
}

Console.WriteLine(mapHolder.Cheats.Where(c => c.Score >= 100).Count());

// 422708
// 982124