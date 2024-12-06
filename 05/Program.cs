using _05;

var input = File.ReadAllText("../../../input.txt");

string[] splitedInput = input.Split("\r\n\r\n");

string[] rulesInput = splitedInput[0].Split("\r\n");
string[] updatesInput = splitedInput[1].Split("\r\n");

List<PageRule> rules = [];
List<Update> update = [];

foreach (string line in rulesInput)
{
    rules.Add(new PageRule(line));
}

foreach (string line in updatesInput)
{
    update.Add(new Update(line));
}

Resolver resolver = new(rules);

List<Update> wrongUpdates = [];
int result = 0;

foreach (Update u in update)
{
    Update? wrongUpdate = resolver.GetWrongUpdate(u);

    if (wrongUpdate != null)
        wrongUpdates.Add(wrongUpdate);

}
Console.WriteLine($"{wrongUpdates.Count} wrongs updates");

int index = 1;
foreach (Update u in wrongUpdates)
{
    Console.WriteLine($"Starting {index} / {wrongUpdates.Count}");
    result += resolver.GetResult(u);
    index++;
}

Console.WriteLine(result);