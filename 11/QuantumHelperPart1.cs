namespace _11
{
    internal class QuantumHelperPart1
    {
        private Dictionary<long, List<long>> _cache;
        public QuantumHelperPart1()
        {
            _cache = [];
        }
        internal long Blink(List<long> data, int nbOfBlinks)
        {
            for (int i = 0; i < nbOfBlinks; i++)
            {
                ApplyRule(data);
            }

            return data.Count;
        }
        private void ApplyRule(List<long> data)
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                var ok = data[i];
                
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