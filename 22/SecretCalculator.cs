
namespace _22
{
    internal class SecretCalculator
    {
        public uint GetSecretNumber(uint startingNumber, int numberOfDays)
        {
            uint secretNumber = startingNumber;
            for (int i = 0; i < numberOfDays; i++)
            {
                secretNumber = Step1(secretNumber);
                secretNumber = Step2(secretNumber);
                secretNumber = Step3(secretNumber);
            }

            Console.WriteLine(secretNumber);
            return secretNumber;
        }

        private uint Step1(uint secretNumber)
        {
            uint result = secretNumber * 64;
            secretNumber = Mix(secretNumber, result);
            secretNumber = Prune(secretNumber);
            return secretNumber;
        }

        private uint Step2(uint secretNumber)
        {
            uint result = (uint)Math.Floor(secretNumber / 32d);
            secretNumber = Mix(secretNumber, result);
            secretNumber = Prune(secretNumber);
            return secretNumber;
        }

        private uint Step3(uint secretNumber)
        {
            uint result = secretNumber * 2048;
            secretNumber = Mix(secretNumber, result);
            secretNumber = Prune(secretNumber);
            return secretNumber;
        }

        private uint Mix(uint secretNumber, uint number)
        {
            var ok = secretNumber ^ number;
            return ok;
        }

        private uint Prune(uint secretNumber)
        {
            uint ok = secretNumber % 16777216;
            return ok;
        }
    }
}
