using System.Diagnostics;

namespace _11
{
    internal class QuantumHelper
    {
        private Dictionary<long, long> _resultsDico;

        public QuantumHelper()
        {
            _resultsDico = [];
        }

        internal long Blink(List<long> data, int nbOfBlinks)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long result = 0;

            foreach (var item in data)
            {
                Console.WriteLine($"Starting item {item}");
                long temp = GetResult(item, nbOfBlinks);
                result += temp;
                Console.WriteLine(temp);
            }

            stopwatch.Stop();
            Console.WriteLine($"Operation took: {stopwatch.Elapsed.TotalSeconds} seconds");

            return result;
        }

        private long GetResult(long item, int nbOfBlinks)
        {
            if (_resultsDico.TryGetValue(item, out var value))
                return value;

            List<long> tempList = [item];

            long result = ApplyRule(tempList, nbOfBlinks);

            _resultsDico.Add(item, result);

            return result;
        }

        private long ApplyRule(List<long> data, int nbOfBlinks)
        {
            long result = 0;

            for (int blink = 0; blink < nbOfBlinks; blink++)
            {
                Console.WriteLine($"{blink + 1}/{nbOfBlinks}");

                for (int i = data.Count - 1; i >= 0; i--)
                {
                    var ok = data[i];

                    //if (_resultsDico.TryGetValue(ok, out var value))
                    //{
                    //    result += value;
                    //    data.RemoveAt(i);
                    //}

                    if (data[i] == 0)
                    {
                        data[i] = 1;
                    }

                    else if (HasEvenDigit(data[i]))
                    {
                        string stringData = data[i].ToString();
                        long leftData = long.Parse(stringData[..(stringData.Length / 2)]);
                        long rightData = long.Parse(stringData[(stringData.Length / 2)..]);

                        data[i] = leftData;
                        data.Insert(i + 1, rightData);
                    }
                    else
                    {
                        long temp = data[i] * 2024;
                        data[i] = temp;
                    }
                }
            }

            return data.Count;
        }

        private static bool HasEvenDigit(long number) => number.ToString().Length % 2 == 0;
    }
}
