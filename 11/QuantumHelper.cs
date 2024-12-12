using System.Diagnostics;

namespace _11
{
    internal class QuantumHelper
    {
        private Dictionary<long, long> _resultsDico;
        private Dictionary<long, long> _tempDico;

        public QuantumHelper()
        {
            _resultsDico = [];
            _tempDico = [];
        }

        internal long Blink(List<long> data, long nbOfBlinks)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            data.ForEach(data => _resultsDico.Add(data, 1));


            for (long i = 0; i < nbOfBlinks; i++)
            {
                ApplyRule(_resultsDico.Where(r => r.Value > 0).Select(r => r.Key).ToList());
                MergeDico();
                Console.WriteLine($"{i + 1}/{nbOfBlinks}");
            }

            stopwatch.Stop();
            Console.WriteLine($"Operation took: {stopwatch.Elapsed.TotalSeconds} seconds");

            long result = 0;

            var ok = _resultsDico.Where(r => r.Value > 0);

            foreach (var value in _resultsDico.Values)
                result += value;

            return result;
        }

        private void ApplyRule(List<long> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                long num = data[i];

                if (num == 0)
                {
                    AddOrUpdateResult(1, num);
                    continue;
                }

                else if (HasEvenDigit(num))
                {
                    string stringData = data[i].ToString();
                    long leftData = long.Parse(stringData[..(stringData.Length / 2)]);
                    long rightData = long.Parse(stringData[(stringData.Length / 2)..]);

                    AddOrUpdateResults(leftData, rightData, num);
                }
                else
                {
                    long temp = data[i] * 2024;
                    AddOrUpdateResult(temp, num);
                }
            }
        }

        private static bool HasEvenDigit(long number) => number.ToString().Length % 2 == 0;

        private void AddOrUpdateResult(long newData, long oldData)
        {
            long value = _resultsDico[oldData];

            if (_tempDico.TryGetValue(newData, out _))
            {
                _tempDico[newData] += value;
            }
            else
            {
                _tempDico.Add(newData, value);
            }

            _tempDico.TryAdd(oldData, 0);
            _tempDico[oldData] -= value;
        }

        private void AddOrUpdateResults(long newData1, long newData2, long oldData)
        {
            long value = _resultsDico[oldData];

            if (_tempDico.TryGetValue(newData1, out _))
            {
                _tempDico[newData1] += value;
            }
            else
            {
                _tempDico.Add(newData1, value);
            }

            if (_tempDico.TryGetValue(newData2, out _))
            {
                _tempDico[newData2] += value;
            }
            else
            {
                _tempDico.Add(newData2, value);
            }

            _tempDico.TryAdd(oldData, 0);
            _tempDico[oldData] -= value;
        }

        private void MergeDico()
        {
            foreach (var item in _tempDico)
            {
                if (_resultsDico.TryGetValue(item.Key, out _))
                {
                    _resultsDico[item.Key] += item.Value;
                }
                else
                {
                    _resultsDico.Add(item.Key, item.Value);
                }
            }
            _tempDico.Clear();
        }
    }
}
