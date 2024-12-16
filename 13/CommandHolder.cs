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

        public long GetTotalPrice()
        {
            long result = 0;

            foreach(var command in Commands)
            {
                (long A, long B) = command.GetNumberOfClicks();
                long temp = (A * TokenA) + (B * TokenB);
                result += temp;
            }

            return result;
        }
    }
}
