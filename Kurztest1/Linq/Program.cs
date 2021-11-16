using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{

    internal struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICollection<Person> people = new List<Person>
            {
                new Person { Name = "Andi", Age = 25 },
                new Person { Name = "Mario", Age = 15 }
            };

            var filteredPeople = from p in people
                                 group p by p.Age into g
                                 let avg = people.Average(x => x.Age)
                                 orderby g.Key descending
                                 select g;

            var test = people.Where(p => p.Age >= 25);
            var test2 = people.FirstOrDefault();
            var test3 = people.Where(p => p.Name.ToUpper().Contains("ANDI"));
            var test4 = people.OrderByDescending(p => p.Age);
        }
    }
}
