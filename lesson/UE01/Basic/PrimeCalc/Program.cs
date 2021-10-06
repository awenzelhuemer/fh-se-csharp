using System;

namespace PrimeCalc
{
    public class PrimeChecker
    {
        const double EPS = 0.1;

        public static bool IsPrime(int number) {

            for (int i = 2; i < Math.Sqrt(number + EPS); i++)
            {
                if(number % i == 0) {
                    return false;
                }
            }
            return true;
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 50;
            int n = 0;
            for (int i = 2; i <= MAX; i++)
            {
                if(PrimeChecker.IsPrime(i))
                {
                    Console.WriteLine(i);
                    n++;
                }
            }

            Console.WriteLine($"Number of prime numbers in [2, {MAX}] = {n}");
        }
    }
}
