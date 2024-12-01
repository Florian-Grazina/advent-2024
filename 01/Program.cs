namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                int delta = Math.Abs(list1[i] - list2[i]);

                result += delta;
            }

            Console.WriteLine(result);
        }
    }
}
