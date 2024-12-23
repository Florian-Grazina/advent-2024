
namespace _23
{
    internal class Computer
    {
        public string Id { get; set; }
        public List<Computer> Lan { get; set; }

        public List<string> LinkedComputers { get; set; }


        public Computer(string id)
        {
            Id = id;
            Lan = [];
            LinkedComputers = Lan.Select(c => c.Id).ToList();
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

        public List<string> GetGroupCount()
        {
            List<string> groupsOf3 = [];

            for(int i = 0; i < Lan.Count; i++)
            {
                for(int j = i; j < Lan.Count; j++)
                {
                    if(i == j) continue;
                    Computer comp1 = Lan[i];
                    Computer comp2 = Lan[j];

                    if(!comp1.IsLinkedTo(comp2))

                }
            }

            return groupsOf3;
        }

        private string CreateGroupOf3(string id1, string id2, string id3)
        {
            var group = new List<string> { id1, id2, id3 };
            group.Sort();
            string ids = string.Join('-', group);
            return ids;
        }
    }
}
