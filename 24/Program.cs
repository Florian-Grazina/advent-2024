using _24;
using _24.Gates;

var input = File.ReadAllText("../../../input.txt");

string wiresData = input.Split("\r\n\r\n")[0];
List<string> commands = new(input.Split("\r\n\r\n")[1].Split("\r\n"));

List<Wire> wires = [];
HashSet<Gate> gates = [new XorGate(), new OrGate(), new AndGate()];

foreach (string wireData in wiresData.Split("\r\n"))
{
    string[] data = wireData.Split(": ");

    string wireId = data[0];
    string wireValue = data[1];
    wires.Add(new Wire(wireId, wireValue));
}

while(commands.Count > 0)
{
    string command = commands.Last();
    commands.RemoveAt(commands.Count - 1);

    string wireId = command.Split(" -> ")[1];
    string gateData = command.Split(" -> ")[0];

    string wireId1 = gateData.Split(" ")[0];
    string gateType = gateData.Split(" ")[1];
    string wireId2 = gateData.Split(" ")[2];

    Wire? input1 = wires.Find(wire => wire.Id == wireId1);
    Wire? input2 = wires.Find(wire => wire.Id == wireId2);

    if(input1 == null || input2 == null)
    {
        commands.Insert(0, command);
        continue;
    }

    Gate gate = gates.First(gate => gate.Id == gateType);

    Wire output = gate.GetWireOutput(input1, input2, wireId);
    wires.Add(output);
}

List<Wire> zWires = wires.FindAll(wire => wire.Id.StartsWith('z'));
zWires.Sort((a, b) => b.Id.CompareTo(a.Id));
string bitValue = string.Join("", zWires.Select(w => w.Value));
Console.WriteLine(Convert.ToInt64(bitValue, 2));