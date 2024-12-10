namespace _10
{
    internal class MapHolder
    {
        public int[,] Map { get; set; }
        public Dictionary<(int, int), TrailHead> TrailHeadDico { get; set; }


        public MapHolder(string[] data)
        {
            TrailHeadDico = [];
            Map = ParseData(data);
        }

        public int GetScore()
        {
            int result = 0;

            foreach(var trailHead in TrailHeadDico.Values)
                result += trailHead.GetScore(Map);

            return result;
        }
        

        private int[,] ParseData(string[] data)
        {
            int[,] map = new int[data.Length, data[0].Length];

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    map[y, x] = int.Parse(data[y][x].ToString());
                    if(map[y, x] == 0)
                        TrailHeadDico.Add((y, x), new TrailHead((y, x)));
                }
            }
            return map;
        }
    }
}
