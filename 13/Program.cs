using _13;

var input = File.ReadAllText("../../../input.txt");

var data = input.Split("\r\n\r\n");

CommandHolder commandHolder = new (data);

decimal result = commandHolder.GetTotalPrice();

Console.WriteLine(result);

// 34093 high
31623
// 14570 low