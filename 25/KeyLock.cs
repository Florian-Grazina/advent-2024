
namespace _25
{
    internal class KeyLock
    {
        public List<int> Combinaison { get; set; }

        public KeyLock(string item)
        {
            Combinaison = [0,0,0,0,0];
            ParseData(item);
        }

        public bool Matches(KeyLock key)
        {
            for (int i = 0; i < Combinaison.Count; i++)
            {
                if (Combinaison[i] + key.Combinaison[i] > 5)
                    return false;
            }
            return true;
        }

        private void ParseData(string item)
        {
            string[] data = item.Split("\r\n");

            foreach (string line in data.Skip(1).Take(5))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '#')
                        Combinaison[i] ++;
                }
            }
        }
    }
}
