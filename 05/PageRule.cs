namespace _05
{
    public class PageRule
    {
        public int Order1 { get; set; }
        public int Order2 { get; set; }

        public PageRule(string input)
        {
            ParseInput(input);
        }

        public bool IsMatch(int order1, int order2)
        {
            return (Order1 == order1 && Order2 == order2);
        }

        private void ParseInput(string input)
        {
            var parts = input.Split("|");
            Order1 = int.Parse(parts[0]);
            Order2 = int.Parse(parts[1]);
        }
    }
}
