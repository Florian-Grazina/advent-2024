using _17;

var input = File.ReadAllText("C:\\Users\\fgrazina.PPI\\Source\\repos\\Florian-Grazina\\advent-2024\\17\\input.txt");

string[] dataRegister = input.Split("\r\n\r\n")[0].Split("\r\n");

Register.A = int.Parse(dataRegister[0].Split(": ")[1]);
Register.B = int.Parse(dataRegister[1].Split(": ")[1]);
Register.C = int.Parse(dataRegister[2].Split(": ")[1]);

List<short> dataProg = input.Split("\r\n\r\n")[1].Split(": ")[1].Split(',').Select(short.Parse).ToList();

Computer computer = new(dataProg);

int regA = int.Parse(args[0]);

while (!AreListsEqualFast(Register.Outputs, Register.ListRef))
{
    regA++;
    Console.WriteLine(regA);
    Reset();
    computer.Run();
}

Console.WriteLine(regA);

void Reset()
{
    Register.A = regA;
    Register.B = int.Parse(dataRegister[1].Split(": ")[1]);
    Register.C = int.Parse(dataRegister[2].Split(": ")[1]);
    Register.Outputs = new();
}

bool AreListsEqualFast(IList<int> list1, IList<int> list2)
{
    if (list1 == null || list2 == null || list1.Count != list2.Count) return false;

    for (int i = 0; i < list1.Count; i++)
    {
        if (list1[i] != list2[i])
            return false;
    }

    return true;
}

// 100 000 000 too low
