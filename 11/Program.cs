using _11;

var input = File.ReadAllText("../../../input.txt").Split(" ");
List<long> data = input.Select(long.Parse).ToList();

QuantumHelper quantumHelper = new();
QuantumHelperPart1 quantumHelper2 = new();

int nb = 7;

long result = quantumHelper.Blink(data, nb);
long result2 = quantumHelper2.Blink(data, nb);

Console.WriteLine(result);
Console.WriteLine(result2);