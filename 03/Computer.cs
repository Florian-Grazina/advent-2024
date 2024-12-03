namespace _03
{
    internal class Computer
    {
        public Stack<ICommand> Commands { get; set; }

        private bool cmdsAreEnabled = true;

        public Computer(List<ICommand> commands)
        {
            commands.Reverse();
            Commands = new(commands);
        }

        public int Run()
        {
            int result = 0;

            while(Commands.Count > 0)
            {
                ICommand cmd = Commands.Pop();

                if (cmd is MulCommand mulCmd && cmdsAreEnabled)
                    result += mulCmd.GetResult();

                else if (cmd is EnableCommand enabledCmd)
                    cmdsAreEnabled = enabledCmd.GetResult();
            }

            return result;
        }
    }
}
