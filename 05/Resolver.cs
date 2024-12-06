using System.Data;

namespace _05
{
    internal class Resolver
    {
        private readonly IEnumerable<PageRule> rules;

        public Resolver(IEnumerable<PageRule> rulesData)
        {
            rules = rulesData;
        }

        public Update? GetWrongUpdate(Update update)
        {
            List<int> listPages = update.ListPages;

            if (IsUpdateCorrect(listPages))
                return null;

            return update;
        }

        public int GetResult(Update update)
        {
            List<int> listPages = update.ListPages;
            List<Tuple<int, int>> rulesTuple = [];

            IEnumerable<PageRule> pageRules = rules.Where(r => listPages.Contains(r.Order1) && listPages.Contains(r.Order2));

            while (!IsUpdateCorrect(listPages))
            {
                Swap(listPages, pageRules);
            }

            return listPages[(listPages.Count - 1) / 2];
        }

        private void Swap(List<int> listPages, IEnumerable<PageRule> pageRules)
        {
            foreach(PageRule pageRule in pageRules)
            {
                if (RuleIsCorrect(listPages, pageRule))
                    continue;

                int index1 = listPages.IndexOf(pageRule.Order1);
                int index2 = listPages.IndexOf(pageRule.Order2);

                (listPages[index1], listPages[index2]) = (listPages[index2], listPages[index1]);
            }
        }

        private bool RuleIsCorrect(List<int> listPages, PageRule pageRule)
        {
            int index1 = listPages.IndexOf(pageRule.Order1);
            int index2 = listPages.IndexOf(pageRule.Order2);

            return index1 < index2;
        }

        private bool IsUpdateCorrect(List<int> listPages)
        {
            var trimmedRules = rules.Where(r => listPages.Contains(r.Order1) && listPages.Contains(r.Order2));

            for (int i = 0; i < listPages.Count - 1; i++)
            {
                for (int y = i + 1; y < listPages.Count; y++)
                {
                    int page1 = listPages[i];
                    int page2 = listPages[y];

                    bool isMatch = false;

                    foreach (PageRule pageRule in trimmedRules)
                    {
                        if (pageRule.IsMatch(page1, page2))
                        {
                            isMatch = true;
                            break;
                        }
                    }

                    if (!isMatch)
                        return false;
                }
            }
            return true;
        }
    }
}
