
string input = File.ReadAllText("../../../input.txt");

// 1649095766

List<int?> explodedData = [];

bool isFiles = true;
int id = 0;

foreach (char c in input)
{
    int nbOfData = int.Parse(c.ToString());

    int? dataToAdd = id;

    if (!isFiles)
    {
        dataToAdd = null;
        id++;
    }

    for (int i = 0; i < nbOfData; i++)
        explodedData.Add(dataToAdd);

    isFiles = !isFiles;
}

List<List<int?>> groupedData = [];

int? lastData = explodedData.FirstOrDefault();
List<int?> groupToAdd = [];

foreach (int? data in explodedData)
{
    if (data == lastData)
        groupToAdd.Add(data);

    else
    {
        lastData = data;
        groupedData.Add(groupToAdd);
        groupToAdd = [];
        groupToAdd.Add(data);
    }
}

groupedData.Add(groupToAdd);

for (int i = (int)explodedData.Last()!; i >= 0; i--)
{
    var groupToMove = groupedData.First(g => g.FirstOrDefault() == i);
    if (groupToMove == null)
        continue;

    //var ok = groupedData.Where(g => g.Count == 0);
    //if (ok.Any())
    //    Console.WriteLine();

    var emptyGroup = groupedData.Find(g => g.First() == null && g.Count >= groupToMove.Count);

    if (emptyGroup != null)
    {
        int indexEmptyGroup = groupedData.IndexOf(emptyGroup);
        int indexGroupToMove = groupedData.IndexOf(groupToMove);

        if (indexEmptyGroup > indexGroupToMove)
            continue;

        groupedData.Insert(groupedData.IndexOf(emptyGroup), groupToMove.ToList());

        indexEmptyGroup = groupedData.IndexOf(emptyGroup);
        indexGroupToMove = groupedData.IndexOf(groupToMove);

        for (int x = 0; x < groupToMove.Count; x++)
            groupedData[indexGroupToMove][x] = null;

        int delta = emptyGroup.Count - groupToMove.Count;
        if (delta == 0)
            groupedData.Remove(emptyGroup);

        else
        {
            for (int index = 0; index < groupToMove.Count; index++)
                emptyGroup.RemoveAt(0);

            FusionEmptyGroup(groupedData, indexEmptyGroup);
        }
    }

    //Print(groupedData);
}

List<int?> listFinal = groupedData.SelectMany(g => g).ToList();

long result = 0;

for (int i = 0; i < listFinal.Count; i++)
{
    if (listFinal[i] != null)
    {
        long res = (int)listFinal[i]! * i;
        result += res;
    }
}

Console.WriteLine(result);












void FusionEmptyGroup(List<List<int?>> groupedData, int index)
{
    // check group after
    if (index < groupedData.Count)
    {
        if (groupedData[index + 1].First() == null)
        {
            groupedData[index].AddRange(groupedData[index + 1]);
            groupedData.RemoveAt(index + 1);
        }
    }

    // check group before
    if (index > 0)
    {
        if (groupedData[index - 1].First() == null)
        {
            groupedData[index].AddRange(groupedData[index - 1]);
            groupedData.RemoveAt(index - 1);
        }
    }
}

void Print(List<List<int?>> groupedData)
{
    foreach (var group in groupedData)
    {
        foreach (var data in group)
        {
            if (data == null)
                Console.Write(".");
            else
                Console.Write(data);
        }
    }
    Console.WriteLine();
}

