
namespace _03
{
    internal class MulCommand : ICommand
    {
        private string command;

        public MulCommand(string cmd)
        {
            command = ParseCommand(cmd);
        }

        public int GetResult()
        {
            string[] parts = command.Split(",");
            int a = int.Parse(parts[0]);
            int b = int.Parse(parts[1]);

            return Multiply(a, b);
        }

        private string ParseCommand(string cmd)
        {
            return cmd.Split("(")[1].Trim(')');
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
