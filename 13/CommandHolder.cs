namespace _13
{
    internal class CommandHolder
    {
        public List<Command> Commands { get; set; }

        public int TokenA = 3;
        public int TokenB = 1;

        public CommandHolder(string[] data)
        {
            Commands = new();

            foreach(var command in data)
            {
                Commands.Add(new Command(command));
            }
        }

        public decimal GetTotalPrice()
        {
            decimal result = 0;

            foreach(var command in Commands)
            {
                (decimal A, decimal B) = command.GetNumberOfClicks();
                result += (A * TokenA) + (B * TokenB);
            }

            return result;
        }
    }
}
