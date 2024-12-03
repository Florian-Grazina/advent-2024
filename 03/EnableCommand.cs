namespace _03
{
    internal class EnableCommand : ICommand
    {
        private bool command;

        public EnableCommand(string cmd)
        {
            command = ParseCommand(cmd);
        }

        public bool GetResult()
        {
            return command;
        }

        private bool ParseCommand(string cmd)
        {
            return cmd switch
            {
                "do()" => true,
                "don't()" => false,
                _ => throw new ArgumentException("Invalid command")
            };
        }
    }
}
