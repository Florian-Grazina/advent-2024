
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
            if (computer == this)
                return true;

            bool isLinked = Lan.Contains(computer);
            return isLinked;
        }

        public List<string> GetGroup()
        {
            List<List<string>> allGroups = [];

            foreach(Computer computer in Lan)
                allGroups.Add(computer.GetLinkedGroup(Lan));

            List<string> intersectGroups = allGroups.Aggregate((current, next) => current.Intersect(next).ToList());
            return intersectGroups;
        }

        public List<string> GetLinkedGroup(List<Computer> computers)
        {
            List<Computer> group = computers.Where(c => c.IsLinkedTo(this)).ToList();
            var ok = group.Select(c => c.Id).ToList();
            ok.Sort();
            return ok;
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
