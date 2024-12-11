using _11;

var input = File.ReadAllText("../../../input.txt").Split(" ");
List<long> data = input.Select(long.Parse).ToList();

QuantumHelper quantumHelper = new();

quantumHelper.Blink(data, 25);

Console.WriteLine(data.Count);