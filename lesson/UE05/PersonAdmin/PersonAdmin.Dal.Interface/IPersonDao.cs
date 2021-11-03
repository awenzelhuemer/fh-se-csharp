using System.Collections.Generic;
using System.Threading.Tasks;
using PersonAdmin.Domain;

namespace PersonAdmin.Dal.Interface
{
    public interface IPersonDao
    {
        #region Public Methods

        Task<IEnumerable<Person>> FindAllAsync();

        Task<Person> FindByIdAsync(int id);

        Task<bool> UpdateAsync(Person person);

        #endregion
    }
}