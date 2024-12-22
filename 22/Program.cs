using _22;

var input = File.ReadAllLines("../../../input.txt");

SecretCalculator calculator = new();
long result = 0;

foreach(string data in input)
{
    result += calculator.GetSecretNumber(int.Parse(data), 2000);
}

Console.WriteLine(result);

// 869068837 low