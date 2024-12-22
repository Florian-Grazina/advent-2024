
namespace _22
{
    internal class SecretCalculator
    {
        private Dictionary<Tuple<int, int, int, int>, int> dico;

        public Dictionary<Tuple<int, int, int, int>, int> GetNumberOfBananas(long startingNumber, int numberOfDays)
        {
            dico = [];
            List<int> sequence = [];
            long secretNumber = startingNumber;
            int lastBanana = (int)(secretNumber % 10);

            for (int i = 0; i < numberOfDays; i++)
            {
                secretNumber = Step1(secretNumber);
                secretNumber = Step2(secretNumber);
                secretNumber = Step3(secretNumber);

                sequence.Add((int)(secretNumber % 10) - lastBanana);
                if (sequence.Count > 4)
                    sequence.RemoveAt(0);

                lastBanana = (int)(secretNumber % 10);

                if(i < 4)
                    continue;

                var sequenceKey = Tuple.Create(sequence[0], sequence[1], sequence[2], sequence[3]);
                dico.TryAdd(sequenceKey, lastBanana);
            }

            return dico;
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
