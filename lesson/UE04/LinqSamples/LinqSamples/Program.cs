using System;
using System.Collections.Generic;
using System.Linq;
using LinqSamples.Data;

namespace LinqSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            static void PrintCustomers(IEnumerable<Customer> customers)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }

            var repository = new CustomerRepository();
            IEnumerable<Customer> customers = repository.GetCustomers();

            Console.WriteLine("==================================");
            Console.WriteLine("Kunden mit mehr als 1 Mio Umsatz");
            Console.WriteLine("----------------------------------");
            //var customersByRevenue = customers.Where(c => c.Revenue > 1000000);
            IEnumerable<Customer> customersByRevenue =
                from c in customers
                where c.Revenue > 1_000_000
                select c;
                
            PrintCustomers(customersByRevenue);

            Console.WriteLine("==================================");
            Console.WriteLine("Kunden, die mit 'A' oder a'");
            Console.WriteLine("----------------------------------");
            //var customersByName =
            //    from c in customers
            //    where c.Name.StartsWith("A", StringComparison.InvariantCultureIgnoreCase)
            //    select c;

            var customersByName = customers.Where(c => c.Name.StartsWith("A", StringComparison.InvariantCultureIgnoreCase));
            PrintCustomers(customersByName);

            Console.WriteLine("==================================");
            Console.WriteLine("Kunden aus Österreich");
            Console.WriteLine("----------------------------------");
            //var customersByCountry = customers.Where(c => c.Location.Country == "Österreich");
            var customersByCountry =
                from c in customers
                where c.Location.Country == "Österreich"
                select c;
            PrintCustomers(customersByCountry);

            Console.WriteLine("==================================");
            Console.WriteLine("Kunde mit vorgegebenem Namen");
            Console.WriteLine("----------------------------------");
            var customer = customers.FirstOrDefault(c => c.Name == "famia");
            Console.WriteLine($"Kunde mit namen 'famia' {customer}");

            Console.WriteLine("==================================");
            Console.WriteLine("Die drei umsatzstärksten Kunden");
            Console.WriteLine("----------------------------------");

            //var cusotmersSortedByRevenue = customers.OrderByDescending(c => c.Revenue).Take(3);
            var customersSortedByRevenue = (from c in customers
                                           orderby c.Revenue descending
                                           select c).Take(3);

            //var top3Customers = customersSortedByRevenue.Take(3);
            PrintCustomers(customersSortedByRevenue);

            Console.WriteLine("==================================");
            Console.WriteLine("Gruppierung nach Land");
            Console.WriteLine("----------------------------------");

            //var customersPerCountry = customers.GroupBy(c => c.Location.Country);
            var customersPerCountry =
                from c in customers
                group c by c.Location.Country into g
                select new { Country = g.Key, Customers = g.Select(c => c) };

            foreach (var group in customersPerCountry.OrderBy(c => c.Country))
            {
                Console.WriteLine(group.Country);
                foreach (var c in group.Customers)
                {
                    Console.WriteLine($" {c}");
                }
            }

            Console.WriteLine("==================================");
            Console.WriteLine("Durchschnittlicher Umsatz pro Land");
            Console.WriteLine("----------------------------------");

            var averageRevenueByCountry =
                from c in customers
                group c by c.Location.Country into g
                select new
                {
                    Country = g.Key,
                    Revenue = g.Average(c => c.Revenue)
                };

            foreach (var group in averageRevenueByCountry.OrderByDescending(c => c.Revenue))
            {
                Console.WriteLine($"{group.Country} {group.Revenue:N2}");
            }
        }
    }
}
