using _17;

var input = File.ReadAllText("../../../input.txt");

string[] dataRegister = input.Split("\r\n\r\n")[0].Split("\r\n");

Register.A = int.Parse(dataRegister[0].Split(": ")[1]);
Register.B = int.Parse(dataRegister[1].Split(": ")[1]);
Register.C = int.Parse(dataRegister[2].Split(": ")[1]);

List<short> dataProg = input.Split("\r\n\r\n")[1].Split(": ")[1].Split(',').Select(short.Parse).ToList();

Computer computer = new(dataProg);
computer.Run();

Console.WriteLine(string.Join(",",Register.Outputs));