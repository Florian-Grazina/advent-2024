namespace _05
{
    internal class Update
    {
        public List<int> ListPages { get; set; }

        public Update(string input)
        {
            ParseInput(input);
        }

        private void ParseInput(string input)
        {
            ListPages = input.Split(",").Select(int.Parse).ToList();
        }
    }
}
