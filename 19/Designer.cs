namespace _19
{
    internal class Designer
    {
        public HashSet<string> Patterns = [];
        public Dictionary<string, bool> DoableDesigns = [];

        public Stack<string> Designs = [];
        public int Score = 0;

        public Designer(List<Towel> towels, string[] designs)
        {
            towels.ForEach(t => Patterns.Add(t.Pattern));
            foreach (var item in designs)
                Designs.Push(item);
        }

        public int GetNumberOfDesigns()
        {
            while (Designs.Count > 0)
            {
                Console.WriteLine($"Designs to check {Designs.Count}");
                string design = Designs.Pop();
                List<string> availableDesigns = [design];
                bool isDesignDoable = false;

                while (true)
                {
                    List<string> newDesigns = [];

                    foreach (var designSub in availableDesigns)
                    {
                        isDesignDoable = CheckDesign(newDesigns, designSub);

                        if (isDesignDoable)
                        {
                            Score++;
                            DoableDesigns.TryAdd(design, true);
                        }
                    }
                    if (newDesigns.Count == 0)
                    {
                        DoableDesigns.TryAdd(design, false);
                        break;
                    }
                    availableDesigns = newDesigns;
                }
            }

            return Score;
        }

        private bool CheckDesign(List<string> matchPatterns, string design)
        {
            //if(DoableDesigns.TryGetValue(design, out bool isDoable))
            //    return isDoable;

            bool toReturn = false;

            foreach (var pattern in Patterns)
            {
                if (design.StartsWith(pattern))
                    matchPatterns.Add(design.Substring(pattern.Length));
             
                if (design == pattern)
                    toReturn = true;
            }

            return toReturn;
        }
    }
}
