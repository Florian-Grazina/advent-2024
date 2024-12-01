namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // number in the left list / score
            Dictionary<int, int> scoreDico = [];

            int result = 0;

            var input = File.ReadAllLines("../../../input.txt");

            List<int> list1 = [];
            List<int> list2 = [];

            foreach(var item in input)
            {
                var split = item.Split("   ");

                list1.Add(int.Parse(split[0]));
                list2.Add(int.Parse(split[1]));
            }

            list1.Sort();
            list2.Sort();

            for(int i = 0; i < list1.Count; i++)
            {
                if (scoreDico.TryGetValue(list1[i], out int score))
                    result += score;

                else
                {
                    score = list2.Where(x => x == list1[i]).Count();
                    score = score * list1[i];
                    scoreDico.Add(list1[i], score);
                    result += score;
                }
            }

            Console.WriteLine(result);
        }
    }
}
