using _19;

var input = File.ReadAllText("../../../input.txt");

string[] towelsData = input.Split("\r\n\r\n")[0].Split(", ");
string[] designData = input.Split("\r\n\r\n")[1].Split("\r\n");

List<Towel> towels = [];
foreach (var item in towelsData)
    towels.Add(new(item));

Designer designer = new(towels, designData);
Console.WriteLine(designer.GetNumberOfDesigns()); 