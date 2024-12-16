using _15;

var input = File.ReadAllText("../../../input.txt").Split("\r\n\r\n");

string map = input[0];
string commands = input[1];

Robot robot = new (commands);

MapHolder mapHolder = new (map, robot);
Console.WriteLine(mapHolder.Run());
