namespace _16
{
    internal static class Database
    {
        public static Dictionary<(int, int), int> History { get; set; } = new();
        public static int Score { get; set; } = 150000;
        public static List<HashSet<(int, int)>> Paths { get; set; } = new();

        public static void SetBestScore(int score, HashSet<(int, int)> path)
        {
            if (score > Score)
                return;

            if(score == Score)
                Paths.Add(path);

            else
            {
                Paths.Clear();
                Paths.Add(path);
                Score = score;
            }
        }
    }
}
