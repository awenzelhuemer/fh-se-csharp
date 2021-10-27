using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable enable

namespace NullableRefTypes
{
    class Program
    {
        static IEnumerable<Person>? GetPersons()
        {
            // ...
            return null;
        }

        static void PrintPersons(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        static bool TryGetPerson(IEnumerable<Person>? persons, string lastName, [NotNullWhen(true)] out Person? person)
        {
            person = persons?.FirstOrDefault(p => p.LastName == lastName) ?? null;
            return person is not null;
        }

        static void Main(string[] args)
        {
            var person = new Person("Huber", "Fritz");
            person.FirstName = null;
            //person.LastName = null; // warning

            var firstUpper = person.FirstName?.ToUpper();
            var lastUpper = person.LastName.ToUpper();

            if (person.FirstName is not null)
            {
                var firstLower = person.FirstName.ToLower(); // no warning
            }
            else
            {
                //var firstLower = person.FirstName.ToLower(); // warning
            }

            IEnumerable<Person>? persons = GetPersons();
            if (persons is not null)
            {
                PrintPersons(persons);
            }

            if (TryGetPerson(persons, "Huber", out Person? p))
            {
                Console.WriteLine(p.LastName); // no warning attribute [NotNullWhen] is used.
            }
        }
    }
}
