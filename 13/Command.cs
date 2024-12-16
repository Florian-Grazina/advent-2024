
using System.Text.RegularExpressions;

namespace _13
{
    internal class Command
    {
        public decimal PrizeX { get; set; }
        public decimal PrizeY { get; set; }

        public decimal AX { get; set; }
        public decimal BX { get; set; }

        public decimal AY { get; set; }
        public decimal BY { get; set; }

        public Command(string data)
        {
            ParseData(data);
        }

        public (long, long) GetNumberOfClicks()
        {
            decimal A = (PrizeX * BY - PrizeY * BX) / ((AX * BY) - (AY * BX));
            decimal B = PrizeY / BY - (AY / BY * A);

            //if (A < 0 || B < 0)
            //    return (0, 0);

            if (!Test((long)Math.Round(A), (long)Math.Round(B)))
                return (0, 0);

            return ((long)Math.Round(A), (long)Math.Round(B));
        }

        private void ParseData(string data)
        {
            Regex regex = new(@"([\d]+)");
            MatchCollection matchCollection = regex.Matches(data);

            AX = decimal.Parse(matchCollection[0].Value);
            AY = decimal.Parse(matchCollection[1].Value);
            BX = decimal.Parse(matchCollection[2].Value);
            BY = decimal.Parse(matchCollection[3].Value);
            PrizeX = decimal.Parse(matchCollection[4].Value) + 10000000000000;
            PrizeY = decimal.Parse(matchCollection[5].Value) + 10000000000000;
            //PrizeX = decimal.Parse(matchCollection[4].Value);
            //PrizeY = decimal.Parse(matchCollection[5].Value);
        }

        private bool Test(decimal a, decimal b)
        {
            if (a * AX + b * BX != PrizeX)
                return false;
            if (a * AY + b * BY != PrizeY)
                return false;

            return true;
        }
    }
}
