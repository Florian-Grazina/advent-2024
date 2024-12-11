using _11;

var input = File.ReadAllText("../../../input.txt").Split(" ");
List<long> data = input.Select(long.Parse).ToList();

QuantumHelper quantumHelper = new();
QuantumHelperPart1 quantumHelper2 = new();

int nb = 75;

long result = quantumHelper.Blink(data, nb);

Console.WriteLine(result);

// 126273763853