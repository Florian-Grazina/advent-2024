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

List<Computer> computersIdT = computers.Where(c => c.Key.Contains('t')).Select(c => c.Value).ToList();

HashSet<string> groupsOf3 = [];


foreach (Computer comp in computersIdT)
{
    foreach (string ids in comp.GetGroupCount())
    {
        if (groupsOf3.Contains(ids))
            continue;

        groupsOf3.Add(ids);
    }
}

Console.WriteLine(groupsOf3.Count);

// 2400 high