using _21;

var data = File.ReadAllLines("../../../input.txt");

var robot = new Roboto();

int result = 0;

foreach(string code in data)
{
    var ok = robot.GetInput(Data.KeyPadDico, [.. code], true);
    var okk = robot.GetInput(Data.ControllerDico, ok, false);
    var okkk = robot.GetInput(Data.ControllerDico, okk, false);

    int score = int.Parse(code.Replace("A", ""));
    Console.WriteLine($"{okkk.Count} x {score}");
    score *= okkk.Count;
    result += score;
}

Console.WriteLine(result);