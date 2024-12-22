using _22;

var input = File.ReadAllLines("../../../input.txt");

SecretCalculator calculator = new();
long result = 0;

HashSet<Tuple<int, int, int, int>> allSequences = new();

for (int a = -9; a <= 9; a++)
    for (int b = -9; b <= 9; b++)
        for (int c = -9; c <= 9; c++)
            for (int d = -9; d <= 9; d++)
                allSequences.Add(Tuple.Create(a, b, c, d));

List<Dictionary<Tuple<int, int, int, int>, int>> ok0 = [];

int index = 0;


foreach (string data in input)
{
    Console.WriteLine($"Adding sequence {index} / {allSequences.Count}");
    index++;
    ok0.Add(new (calculator.GetNumberOfBananas(int.Parse(data), 2000)));
}

index = 0;

foreach (var item in allSequences)
{
    long highScore = 0;
    Console.WriteLine($"Calulating sequence {index} / {allSequences.Count}");
    index++;

    foreach (var sequence in ok0)
        if (sequence.TryGetValue(item, out int value))
            highScore += value;

    if (highScore > result)
        result = highScore;
}

Console.WriteLine(result);

// 14715 high