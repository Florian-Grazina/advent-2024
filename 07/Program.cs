using _07;

var input = File.ReadAllLines("../../../input.txt");

List<Equation> equations = [];
foreach (var line in input)
{
    equations.Add(new Equation(line));
}

long result = equations.Sum(e => e.GetResult());
Console.WriteLine(result);