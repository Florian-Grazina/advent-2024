namespace _11
{
    internal class QuantumHelper
    {
        private Dictionary<long, List<long>> _cache;

        public QuantumHelper()
        {
            _cache = [];
        }

        internal void Blink(List<long> data, int nbOfBlinks)
        {
            for (int i = 0; i < nbOfBlinks; i++)
            {
                ApplyRule(data);
                //Console.WriteLine(string.Join(" ", data));
                Console.WriteLine($"");
            }
        }

        private void ApplyRule(List<long> data)
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                var ok = data[i];

                if(_cache.TryGetValue(ok, out var value))
                {
                    data[i] = value[0];
                    data.InsertRange(i + 1, value.);
                    continue;
                }

                if (data[i] == 0)
                    data[i] = 1;

                else if (HasEvenDifit(data[i]))
                {
                    string stringData = data[i].ToString();

                    string leftData = stringData[..(stringData.Length / 2)];
                    string rightData = stringData[(stringData.Length / 2)..];

                    data[i] = long.Parse(leftData);
                    data.Insert(i + 1, long.Parse(rightData));
                }

                else
                    data[i] = data[i] * 2024;
            }
        }

        private static bool HasEvenDifit(long number) => number.ToString().Length % 2 == 0;
    }
}
