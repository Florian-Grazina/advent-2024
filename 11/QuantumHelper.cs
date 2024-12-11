using System.Diagnostics;

namespace _11
{
    internal class QuantumHelper
    {
        private Dictionary<uint, uint> _cache;

        public QuantumHelper()
        {
            _cache = [];
        }

        internal uint Blink(List<uint> data, int nbOfBlinks)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            uint result = 0;

            foreach (var item in data)
            {
                result += GetResult(item, nbOfBlinks);
            }

            //Console.WriteLine(string.Join(" ", data));

            stopwatch.Stop();
            Console.WriteLine($"Operation took: {stopwatch.Elapsed.TotalSeconds} seconds");

            return result;
        }

        private uint GetResult(uint item, int nbOfBlinks)
        {
            if (_cache.TryGetValue(item, out var value))
                return value;

            List<uint> tempList = [item];

            for (int i = 0; i < nbOfBlinks; i++)
            {
                ApplyRule(tempList);
            }

            uint result = (uint)tempList.Count;

            _cache.Add(item, result);

            return result;
        }

        private void ApplyRule(List<uint> data)
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (data[i] == 0)
                    data[i] = 1;

                else if (HasEvenDifit(data[i]))
                {
                    string stringData = data[i].ToString();

                    uint leftData = uint.Parse(stringData[..(stringData.Length / 2)]);
                    uint rightData = uint.Parse(stringData[(stringData.Length / 2)..]);

                    data[i] = leftData;
                    data.Insert(i + 1, rightData);
                }

                else
                {
                    uint result = data[i] * 2024;
                    if (result > 4294967295) throw new Exception("Overflow");
                    data[i] = result;
                }
            }
        }

        private static bool HasEvenDifit(uint number) => number.ToString().Length % 2 == 0;
    }
}
