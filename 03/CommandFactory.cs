namespace _03
{
    internal static class CommandFactory
    {
        public static ICommand CreateCommand(string cmd)
        {
            if (cmd.StartsWith("mul"))
                return new MulCommand(cmd);

            return new EnableCommand(cmd);
        }
    }
}
