
namespace _22
{
    internal class SecretCalculator
    {
        public long GetSecretNumber(long startingNumber, int numberOfDays)
        {
            long secretNumber = startingNumber;
            for (int i = 0; i < numberOfDays; i++)
            {
                secretNumber = Step1(secretNumber);
                secretNumber = Step2(secretNumber);
                secretNumber = Step3(secretNumber);
            }

            Console.WriteLine(secretNumber);
            return secretNumber;
        }

        private long Step1(long secretNumber)
        {
            long result = secretNumber * 64;
            secretNumber = Mix(secretNumber, result);
            secretNumber = Prune(secretNumber);
            return secretNumber;
        }

        private long Step2(long secretNumber)
        {
            long result = (long)Math.Floor(secretNumber / 32f);

            secretNumber = Mix(secretNumber, result);
            secretNumber = Prune(secretNumber);
            return secretNumber;
        }

        private long Step3(long secretNumber)
        {
            long result = secretNumber * 2048;
            secretNumber = Mix(secretNumber, result);
            secretNumber = Prune(secretNumber);
            return secretNumber;
        }

        private long Mix(long secretNumber, long number)
        {
            var ok = secretNumber ^ number;
            return ok;
        }

        private long Prune(long secretNumber)
        {
            long ok = secretNumber % 16777216;
            return ok;
        }
    }
}
