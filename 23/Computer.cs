namespace _23
{
    internal class Computer
    {
        public string Id { get; set; }
        public List<Computer> Lan { get; set; }
        public Computer(string id)
        {
            Id = id;
            Lan = [];
        }
        public void LinkTo(Computer computer)
        {
            Lan.Add(computer);
        }
        public bool IsLinkedTo(Computer computer)
        {
            bool isLinked = Lan.Contains(computer);
            return isLinked;
        }
        public List<string> GetGroups()
        {
            List<List<Computer>> groupsOf3 = [];
            for(int i = 0; i < Lan.Count; i++)
            {
                for(int j = i; j < Lan.Count; j++)
                {
                    if(i == j) continue;
                    Computer comp1 = Lan[i];
                    Computer comp2 = Lan[j];
                    if(comp1.IsLinkedTo(comp2))
                        groupsOf3.Add(CreateGroupOf3(this, comp1, comp2));
                }
            }

            foreach(List<Computer> group in groupsOf3)
            {
                foreach(Computer comp in Lan)
                {
                    if(group.Contains(comp))
                        continue;

                    if(group.All(group => group.IsLinkedTo(comp)))
                        group.Add(comp);
                }
            }

            var ok = groupsOf3.Select(CreateId).ToList();
            return ok;
        }

        private List<Computer> CreateGroupOf3(Computer id1, Computer id2, Computer id3)
        {
            var group = new List<Computer> { id1, id2, id3 };
            return group;
        }

        private string CreateId(List<Computer> comps)
        {
            var group = comps.Select(c => c.Id).ToList();
            group.Sort();
            string ids = string.Join(',', group);
            return ids;
        }
    }
}