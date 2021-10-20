using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonManagement
{
    class Program
    {
        private static void Main()
        {
            PersonRepository personRepository = new PersonRepository();
            IEnumerable<Person> persons = new List<Person>();

            try
            {
                using (var reader = new StreamReader("persons.json"))
                {
                    var json = reader.ReadToEnd();
                    persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                personRepository.AddPersons(persons);
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine(fnfEx.Message);
                return;
            }

            using TextWriter textWriter = Console.Out;
            //TextWriter textWriter = new StreamWriter("log.txt");

            textWriter.WriteLine("=====================================================");
            textWriter.WriteLine("Person list");
            textWriter.WriteLine("=====================================================");
            personRepository.PrintPersons(textWriter);

            textWriter.WriteLine();
            textWriter.WriteLine("=====================================================");
            textWriter.WriteLine("Persons in Hagenberg");
            textWriter.WriteLine("=====================================================");
            foreach (var person in personRepository.FindPersonsByCity("Hagenberg"))
            {
                Console.WriteLine(person);
            }

            textWriter.WriteLine();
            textWriter.WriteLine("=====================================================");
            textWriter.WriteLine("Person names");
            textWriter.WriteLine("=====================================================");
            foreach (var (first, last) in personRepository.GetPersonNames())
            {
                Console.WriteLine($"{first} {last}");
            }

            textWriter.WriteLine();
            textWriter.WriteLine("=====================================================");
            textWriter.WriteLine($"Youngest person");
            textWriter.WriteLine("=====================================================");
            Console.WriteLine(personRepository.FindYoungestPerson());

            //textWriter.WriteLine();
            //textWriter.WriteLine("=====================================================");
            //textWriter.WriteLine("Persons sorted by age ascending");
            //textWriter.WriteLine("=====================================================");
            //
            // TODO
            //
        }
    }
}
