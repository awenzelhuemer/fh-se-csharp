using System;
using System.Collections.Generic;
using System.IO;
using Swk5.Extensions;

namespace PersonManagement
{
    public class PersonRepository
    {
        private readonly IList<Person> persons = new List<Person>();

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }

        public void AddPersons(IEnumerable<Person> persons)
        {
            this.persons.AddAll(persons);
        }

        public void PrintPersons(TextWriter textWriter)
        {
            // variant 1
            //foreach (var person in persons)
            //{
            //    textWriter.WriteLine(person);
            //}

            // variant 2
            //Action<Person> printActions = delegate (Person person)
            //{
            //    textWriter.WriteLine(person);
            //};
            //persons.ForEach(printActions);

            // variant 3
            //persons.ForEach(delegate (Person person)
            //{
            //    textWriter.WriteLine(person);
            //});

            // variant 4
            persons.ForEach(p => textWriter.WriteLine(p));
        }

        public IEnumerable<(string, string)> GetPersonNames()
        {
            // Variant 1
            //foreach (var person in persons)
            //{
            //    yield return (person.FirstName, person.LastName);
            //}

            // Variant 2
            return persons.Map(person => (person.FirstName, person.LastName));
        }

        public IEnumerable<Person> FindPersonsByCity(string city)
        {
            // Variante 1
            //foreach (var person in persons)
            //{
            //    if(person.City == city)
            //    {
            //        yield return person;
            //    }
            //}

            // Variante 2
            return persons.Filter(person => person.City == city);
        }

        public Person FindYoungestPerson()
        {
            Person youngest = null;

            foreach (var person in persons)
            {
                if(youngest == null || youngest.DateOfBirth < person.DateOfBirth)
                {
                    youngest = person;
                }
            }
            return youngest;
        }


        public IEnumerable<Person> FindPersonsSortedByAgeAscending()
        {
            return null;
        }
    }
}
