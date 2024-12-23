namespace _21
{
    internal static class Data
    {
        public static Dictionary<char, (int, int)> KeyPadDico = new()
        {
            {'7', (0, 0)},
            {'8', (0, 1)},
            {'9', (0, 2)},

            {'4', (1, 0)},
            {'5', (1, 1)},
            {'6', (1, 2)},

            {'1', (2, 0)},
            {'2', (2, 1)},
            {'3', (2, 2)},

            {'0', (3, 1)},
            {'A', (3, 2)},
        };

        public static Dictionary<char, (int, int)> ControllerDico = new()
        {
            {'^', (0, 1)},
            {'A', (0, 2)},

            {'<', (1, 0)},
            {'v', (1, 1)},
            {'>', (1, 2)},
        };
    }
}
