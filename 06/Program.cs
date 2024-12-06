using _06;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new(input);
int result = mapHolder.Run();
Console.WriteLine(result);

// 5324
// 5444

// 78
// 79