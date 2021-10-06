using System.Collections.Generic;
using System;
using PrimeCalc.Math;
using Newtonsoft.Json;

namespace PrimeCalc.Client
{
    class Program
    {
        const int DEFAULT_LIMIT = 20;

        static void PrintPrimesAsJson(int limit) {
            int n = 0;
            var primes = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if(PrimeChecker.IsPrime(i))
                {
                    n++;
                    primes.Add(i);
                }
            }

            string json = JsonConvert.SerializeObject(
                new { Count = n, Primes = primes});
            Console.WriteLine(json);
        }

        static void TestPrimeChecker() {
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

        static void Main(string[] args)
        {
            int limit = args.Length == 1 ? int.Parse(args[0]) : DEFAULT_LIMIT;
            PrintPrimesAsJson(limit);
        }
    }
}
