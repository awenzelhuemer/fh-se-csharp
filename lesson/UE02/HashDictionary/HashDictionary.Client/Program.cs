using System;
using System.Collections.Generic;
using System.Linq;
using HashDictionary.Impl;

namespace HashDictionary.Client
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            var cityInfo = TestIndexerAndAdd();
            PrintHashDictionary(cityInfo);

            if(cityInfo.TryGetValue("Eferding", out int value)) {
                Console.WriteLine(value);
            }

            Console.WriteLine("Keys: " + string.Join(',', cityInfo.Keys));

            Console.WriteLine("Remove eferding");
            cityInfo.Remove("Eferding");

            PrintHashDictionary(cityInfo);
        }

        private static void PrintHashDictionary<TKey, TValue>(IDictionary<TKey, TValue> cityInfo)
        {
            foreach (var item in cityInfo)
            {
                Console.WriteLine(item);
            }
        }

        private static IDictionary<string, int> TestIndexerAndAdd()
        {
            var cityInfo = new HashDictionary<string, int>();
            try
            {
                cityInfo["Hagenberg"] = 2_590;
                cityInfo["Linz"] = 200_000;
                cityInfo["Eferding"] = 3_678;
                cityInfo.Add("Wien", 1_800_000);
                cityInfo["Linz"] = 205_000;

                Console.WriteLine($"cityInfo[\"Hagenberg\"] -> {cityInfo["Hagenberg"]}");
                Console.WriteLine($"cityInfo[\"Linz\"] -> {cityInfo["Linz"]}");
                Console.WriteLine($"cityInfo[\"Wien\"] -> {cityInfo["Wien"]}");
                Console.WriteLine($"cityInfo[\"Eferding\"] -> {cityInfo["Eferding"]}");

                cityInfo.Add("Wien", 1_900_000);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            return cityInfo;
        }

        #endregion
    }
}