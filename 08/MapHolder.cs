

namespace _08
{
    internal class MapHolder
    {
        public char[,] Map { get; set; }
        public List<Antenna> Ants { get; set; }
        public Dictionary<(int, int), char> FrenquencyDico { get; set; }


        public MapHolder(string[] data)
        {
            Ants = [];
            FrenquencyDico = [];
            Map = ParseData(data);
            GetFrequencies();
            Print();
        }


        private void Print()
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Console.Write(Map[y, x]);
                }
                Console.WriteLine();
            }
        }

        private char[,] ParseData(string[] data)
        {
            char[,] map = new char[data.Length, data[0].Length];

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    map[y, x] = data[y][x];

                    if(map[y, x] != '.')
                    {
                        Ants.Add(new Antenna((y, x), map[y, x]));
                        FrenquencyDico.Add((y, x), map[y, x]);
                    }
                }
            }
            return map;
        }

        private void GetFrequencies()
        {
            List<IGrouping<char, Antenna>> groupsAnts = Ants.GroupBy(x => x.Frenquency).ToList();

            foreach(IGrouping<char, Antenna> groupAnts in groupsAnts)
            {
                List<Antenna> listAnts = groupAnts.ToList();

                for (int i = 0; i < listAnts.Count; i++)
                {
                    for (int j = 1; j < listAnts.Count; j++)
                    {
                        if (i == j)
                            continue;

                        CalculateFrenquencies(listAnts[i].Coords, listAnts[j].Coords);
                        CalculateFrenquencies(listAnts[j].Coords, listAnts[i].Coords);
                    }
                }
            }
        }

        private void CalculateFrenquencies((int, int) ant1, (int, int) ant2)
        {
            int deltaY = ant1.Item1 - ant2.Item1;
            int deltaX = ant1.Item2 - ant2.Item2;

            (int, int) frequencyCoords = (ant1.Item1 + deltaY, ant1.Item2 + deltaX);

            if (IsInBound(frequencyCoords))
            {
                if (!FrenquencyDico.ContainsKey(frequencyCoords))
                    FrenquencyDico.Add(frequencyCoords, 'X');

                Map[frequencyCoords.Item1, frequencyCoords.Item2] = 'X';

                CalculateFrenquencies(frequencyCoords, ant1);
            }
        }

        private bool IsInBound((int, int) coords)
        {
            if (coords.Item1 < 0 || coords.Item1 >= Map.GetLength(0))
                return false;

            else if (coords.Item2 < 0 || coords.Item2 >= Map.GetLength(1))
                return false;

            return true;
        }
    }
}
