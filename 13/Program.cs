using _13;

var input = File.ReadAllText("../../../input.txt");

var data = input.Split("\r\n\r\n");

CommandHolder commandHolder = new (data);

decimal result = commandHolder.GetTotalPrice();

Console.WriteLine(result);

// 124701495431420430
// 95329548166047

// 93209116744825 -- correct
// 93209116744803