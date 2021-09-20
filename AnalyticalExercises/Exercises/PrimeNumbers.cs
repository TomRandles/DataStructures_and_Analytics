using System.Collections.Generic;

namespace AnalyticalExercises.Exercises
{
    public class PrimeNumbers
    {
        public static List<int> GetPrimeNumbers(byte primeNumbersToGet)
        {
            var primeNumbersFound = new List<int>();
            int counter = 1;
            while (primeNumbersFound.Count < primeNumbersToGet) 
            {
                if ((counter == 1) || (counter == 2) || (counter == 3))
                {
                    primeNumbersFound.Add(counter);
                }
                
                primeNumbersFound.Add((6*counter)-1);
                primeNumbersFound.Add((6*counter)+1);
                counter++;
            }

            return primeNumbersFound;
        }
    }
}
