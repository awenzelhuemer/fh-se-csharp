using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Domain;

namespace PersonAdmin.Dal.Simple
{
    public class SimplePersonDao : IPersonDao
    {
        #region Private Fields

        private static readonly IList<Person> personList = new List<Person>
        {
          new Person { Id=1, FirstName="John", LastName="Doe",        DateOfBirth=DateTime.Now.AddYears(-10) },
          new Person { Id=2, FirstName="Jane", LastName="Doe",        DateOfBirth=DateTime.Now.AddYears(-20) },
          new Person { Id=3, FirstName="Max",  LastName="Mustermann", DateOfBirth=DateTime.Now.AddYears(-30) }
        };

        #endregion

        #region Public Methods

        public async Task<IEnumerable<Person>> FindAllAsync()
        {
            var list = personList;
            return await Task.FromResult(list);
        }

        public async Task<Person> FindByIdAsync(int id)
        {
            var result = personList.SingleOrDefault(p => p.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            var personToUpdate = await FindByIdAsync(person.Id);

            if (personToUpdate is null)
            {
                return await Task.FromResult(false);
            }

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.DateOfBirth = person.DateOfBirth;

            return await Task.FromResult(true);
        }

        #endregion
    }
}