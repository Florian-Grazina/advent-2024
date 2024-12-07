

namespace _07
{
    internal class Equation
    {
        public long Result { get; set; }
        public List<int> Numbers { get; set; }


        public Equation(string data)
        {
            Numbers = [];
            ParseData(data);
        }

        public long GetResult()
        {
            long total = Numbers.First();

            return Calculcate(total, 1);
        }

        private long Calculcate(long total, int index)
        {
            if (index == Numbers.Count)
                return total;

            if (Calculcate(total + Numbers[index], index + 1) == Result)
                return Result;

            else if (Calculcate(total * Numbers[index], index + 1) == Result)
                return Result;

            else if (Calculcate(long.Parse($"{total}{Numbers[index]}"), index + 1) == Result)
                return Result;

            return 0;
        }

        private void ParseData(string data)
        {
            string[] input = data.Split(": ");

            Result = long.Parse(input[0]);
            Numbers = input[1].Split(" ").Select(int.Parse).ToList();
        }
    }
}
