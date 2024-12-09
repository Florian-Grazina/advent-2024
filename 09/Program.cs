string input = File.ReadAllText("../../../input.txt");

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

long result = 0;

for (int i = 0; i < explodedData.Count; i++)
{
    if (explodedData[i] != null)
    {
        result += (int)explodedData[i]! * i;
        continue;
    }

    int? valueToSwap;

    do
    {
        valueToSwap = explodedData.Last();
        explodedData.RemoveAt(explodedData.Count - 1);
    }
    while(valueToSwap == null);

    explodedData[i] = valueToSwap;
    result += (int)explodedData[i]! * i;
}

Console.WriteLine(result);