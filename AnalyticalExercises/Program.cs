using AnalyticalExercises.Exercises;
using System;
using System.Linq;

namespace AnalyticalExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Prime number exercises");
            Console.WriteLine();
            Console.Write("Input number of prime numbers required: ");
            var input = Console.ReadLine();

            var primeNumbers = PrimeNumbers.GetPrimeNumbers(10);
            foreach (var pn in primeNumbers.OrderBy(i => i))
                Console.WriteLine(pn);
        }
    }
}