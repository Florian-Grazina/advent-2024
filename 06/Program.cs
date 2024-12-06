using _06;

var input = File.ReadAllLines("../../../input.txt");

MapHolder mapHolder = new(input);
int result = mapHolder.RunV2();
Console.WriteLine(result);

// 5324
// 5444

// 78
// 79
// 457
// 1839
// 1840
// 1857
// 1858
// 1859
// 1860