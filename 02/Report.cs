

namespace _02
{
    internal class Report
    {
        public List<int> Levels = default!;

        public bool IsIncreasing;

        public Report(string input)
        {
            ParseInput(input);
        }

        public bool IsSafe()
        {
            IsIncreasing = GetIsIncreasing();
            bool isDempedUsed = false;

            for (int i = 0; i < Levels.Count - 1; i++)
            {
                int delta;

                if (IsIncreasing)
                    delta = Levels[i + 1] - Levels[i];
                else
                    delta = Levels[i] - Levels[i + 1];

                if (delta == 1 || delta == 2 || delta == 3)
                    continue;
                else
                {
                    if (isDempedUsed)
                        return false;

                    isDempedUsed = true;

                    if (i == 0)
                        Levels[i] = Levels[i + 1];
                    else
                        Levels[i + 1] = Levels[i];
                }
            }
            return true;
        }

        private bool GetIsIncreasing()
        {
            int inscreaseCount = 0;
            int decreaseCount = 0;

            for (int i = 0; i < Levels.Count - 1; i++)
            {
                if (Levels[i] < Levels[i + 1])
                    inscreaseCount++;
                else
                    decreaseCount++;
            }
            return inscreaseCount > decreaseCount;
        }

        private void ParseInput(string input)
        {
            var array = input.Split(' ');
            Levels = array.Select(int.Parse).ToList();
        }
    }
}
