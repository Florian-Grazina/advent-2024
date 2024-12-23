using _23;

var input = File.ReadAllLines("../../../input.txt");

Dictionary<string, Computer> computers = [];

foreach (var data in input)
{
    string comp1Id = data.Split("-")[0];
    string comp2Id = data.Split("-")[1];

    if (!computers.TryGetValue(comp1Id, out Computer comp1))
    {
        comp1 = new Computer(comp1Id);
        computers.Add(comp1.Id, comp1);
    }

    if (!computers.TryGetValue(comp2Id, out Computer comp2))
    {
        comp2 = new Computer(comp2Id);
        computers.Add(comp2.Id, comp2);
    }

    comp1.LinkTo(comp2);
    comp2.LinkTo(comp1);
}


string highestId = "";

foreach (Computer comp in computers.Values)
{
    foreach (string ids in comp.GetGroups())
    {
        if (ids.Length > highestId.Length)
            highestId = ids;
    }
}


Console.WriteLine(highestId);

// hl - io - ku - pk - ps - qq - sh - tx - ty - wq - xi - xj - yp
