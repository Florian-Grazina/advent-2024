namespace _16
{
    internal static class Database
    {
        public static Dictionary<(int, int), int> History { get; set; } = new();
        public static int Score { get; set; } = 150000;

        public static void SetBestScore(int score)
        {
            if (score >= Score)
                return;

            Score = score;
        }
    }
}
