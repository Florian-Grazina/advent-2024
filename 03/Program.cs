using _03;
using System.Text.RegularExpressions;

string input = File.ReadAllText("../../../input.txt");

Regex regex = new(@"(mul\(\d+,\d+\))|(don't\(\))|(do\(\))");
MatchCollection matchCollection = regex.Matches(input);

List<ICommand> commands = [];
foreach (Match match in matchCollection)
{
    if(string.IsNullOrEmpty(match.Value))
        continue;
    commands.Add(CommandFactory.CreateCommand(match.Value));
}

Computer computer = new(commands);
int result = computer.Run();

Console.WriteLine(result);