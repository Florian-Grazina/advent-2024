

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
            IsSafe = GetIsSafeV2();
        }

        public bool GetIsSafe()
        {
            IsIncreasing = GetIsIncreasing();

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

        public bool GetIsSafeV2()
        {
            IsIncreasing = GetIsIncreasing();

            if (CheckReport(Levels))
                return true;

            else
                for (int i = 0; i < Levels.Count; i++)
                    if (CheckReport(Levels, i))
                        return true;

            return false;
        }

        private bool CheckReport(List<int> data, int? indexToSkip = null)
        {
            List<int> trimmedData = data.ToList();

            if (indexToSkip.HasValue)
                trimmedData.RemoveAt(indexToSkip.Value);

            for (int i = 0; i < trimmedData.Count - 1; i++)
            {
                if (!DeltaIsIn(trimmedData[i], trimmedData[i + 1]))
                    return false;
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
