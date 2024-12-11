using _11;

var input = File.ReadAllText("../../../input.txt").Split(" ");
List<uint> data = input.Select(uint.Parse).ToList();

QuantumHelper quantumHelper = new();

uint result = quantumHelper.Blink(data, 25);

Console.WriteLine(result);