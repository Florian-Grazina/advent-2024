

namespace _02
{
    internal class Report
    {
        public List<int> Levels = default!;
        public bool IsIncreasing;
        public bool IsSafe = true;

        public Report(string input)
        {
            ParseInput(input);
            IsSafe = GetIsSafe();
        }

        public bool GetIsSafe()
        {
            IsIncreasing = GetIsIncreasing();
            if (!IsSafe)
                return false;

            bool isDempedUsed = false;

            for (int i = 0; i < Levels.Count - 1; i++)
            {
                if (DeltaIsIn(Levels[i], Levels[i + 1]))
                    continue;

                else
                {
                    if (isDempedUsed)
                        return false;

                    isDempedUsed = true;

                    if (i == 0)
                    {
                        if(DeltaIsIn(Levels[i], Levels[i + 2]))
                            Levels[i + 1] = Levels[i];
                    }

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

            if (inscreaseCount >= 2 && decreaseCount >= 2)
                IsSafe = false;

            return inscreaseCount > decreaseCount;
        }

        private void ParseInput(string input)
        {
            var array = input.Split(' ');
            Levels = array.Select(int.Parse).ToList();
        }

        private bool DeltaIsIn(int num1, int num2)
        {
            int delta;

            if (IsIncreasing)
                delta = num2 - num1;
            else
                delta = num1 - num2;

            if (delta == 1 || delta == 2 || delta == 3)
                return true;

            return false;
        }
    }
}
