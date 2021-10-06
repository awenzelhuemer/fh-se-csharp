using System.Collections.Generic;
using System;
using PrimeCalc.Math;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;

namespace PrimeCalc.Client
{
    class Program
    {
        static void PrintPrimesAsJson() {
            const int MAX = 50;
            int n = 0;
            var primes = new List<int>();
            for (int i = 2; i <= MAX; i++)
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

        static void PrintProgramName()
        {
            Console.WriteLine($"{Thread.CurrentThread.CurrentUICulture}: {Resources.GetString("ProgramName")}");

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-AT");
            Console.WriteLine($"{Thread.CurrentThread.CurrentUICulture}: {Resources.GetString("ProgramName")}");
        }

        static void Main(string[] args)
        {
            PrintProgramName();
            PrintPrimesAsJson();
        }
    }
}
