using _08;

var input = File.ReadAllLines("../../../input.txt");

MapHolder map = new (input);
Console.WriteLine(map.FrenquencyDico.Count);