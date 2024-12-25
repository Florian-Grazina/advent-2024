using _25;

var input = File.ReadAllText("../../../input.txt");

string[] data = input.Split("\r\n\r\n");

List<KeyLock> locks = [];
List<KeyLock> keys = [];

foreach (string item in data)
{
    if (item[0] == '#')
        locks.Add(new KeyLock(item));
    else
        keys.Add(new KeyLock(item));
}

int result = 0;

foreach(KeyLock item in locks)
{
    foreach (KeyLock key in keys)
    {
        if(item.Matches(key))
            result++;
    }
}

Console.WriteLine(result);