
using System.Text.RegularExpressions;

namespace _13
{
    internal class Command
    {
        public decimal PrizeX { get; set; }
        public decimal PrizeY {get; set;}

        public decimal AX {get; set;}
        public decimal BX {get; set;}

        public decimal AY {get; set;}
        public decimal BY {get; set;}

        public Command(string data)
        {
            ParseData(data);
        }

        public (decimal, decimal) GetNumberOfClicks()
        {
            decimal A = (PrizeX * BY - PrizeY * BX) / ((AX * BY) - (AY * BX));
            decimal B = PrizeY / BY - (AY / BY * A);

            if (A > 100 || B > 100)
                return (0, 0);

            else if (A < 0 || B < 0)
                return (0, 0);

            else if(!IsDecimalWhole(A) && !IsDecimalWhole(B))
                return (0, 0);

            return (A, B);
        }

        private void ParseData(string data)
        {
            Regex regex = new(@"([\d]+)");
            MatchCollection matchCollection = regex.Matches(data);

            AX = decimal.Parse(matchCollection[0].Value);
            AY = decimal.Parse(matchCollection[1].Value);
            BX = decimal.Parse(matchCollection[2].Value);
            BY = decimal.Parse(matchCollection[3].Value);
            PrizeX = decimal.Parse(matchCollection[4].Value);
            PrizeY = decimal.Parse(matchCollection[5].Value);
        }

        bool IsDecimalWhole(decimal value)
        {
            return value % 1 == 0;
        }

    }
}
