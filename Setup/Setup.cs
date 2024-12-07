using System.Diagnostics;

string projectName = args[0];

string solutionPath = AppContext.BaseDirectory + "..\\..\\..\\..\\";
string projectPath = Path.Combine(solutionPath, projectName);

ExecuteCommand($"dotnet new console -n {projectName} -o \"{projectPath}\"");
ExecuteCommand($"dotnet sln \"{solutionPath}\" add \"{Path.Combine(projectPath, projectName)}.csproj\"");

File.WriteAllText(Path.Combine(projectPath, "input.txt"), "");

string programCsPath = Path.Combine(projectPath, "Program.cs");
if (File.Exists(programCsPath))
{
    string code = @"
var input = File.ReadAllLines(""../../../input.txt"");";
    
    File.WriteAllText(programCsPath, code.Trim());
}

static void ExecuteCommand(string command)
{
    var processInfo = new ProcessStartInfo("cmd.exe", $"/c {command}")
    {
        CreateNoWindow = true,
        UseShellExecute = false,
    };

    using var process = Process.Start(processInfo);
    process?.WaitForExit();
}
