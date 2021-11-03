using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dal.Common;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Domain;

namespace PersonAdmin.Dal.Ado
{
    public class AdoPersonDao : IPersonDao
    {
        #region Private Fields

        private readonly AdoTemplate template;

        #endregion

        #region Public Constructors

        public AdoPersonDao(IConnectionFactory connectionFactory)
        {
            template = new(connectionFactory);
        }

        #endregion

        #region Private Methods

        private static Person MapPerson(IDataRecord row) => new()
        {
            Id = (int)row["id"],
            FirstName = (string)row["first_name"],
            LastName = (string)row["last_name"],
            DateOfBirth = (DateTime)row["date_of_birth"]
        };

        #endregion

        #region Public Methods

        public async Task<IEnumerable<Person>> FindAllAsync()
        {
            return await template.QueryAsync("select * from person", MapPerson);
        }

        public async Task<Person> FindByIdAsync(int id)
        {
            return await template.QuerySingleAsync($"select * from person where id = @id", MapPerson, new QueryParameter("id", id));
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            return await template.ExecuteAsync("update person set first_name = @fn, last_name = @ln, date_of_birth = @dob where id = @id",
                new QueryParameter("fn", person.FirstName),
                new QueryParameter("ln", person.LastName),
                new QueryParameter("dob", person.DateOfBirth),
                new QueryParameter("id", person.Id)) == 1;
        }

        #endregion
    }
}