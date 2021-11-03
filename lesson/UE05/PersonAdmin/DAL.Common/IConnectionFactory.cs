using System.Data.Common;
using System.Threading.Tasks;

namespace Dal.Common
{
    public interface IConnectionFactory
    {
        #region Public Properties

        string ConnectionString { get; }

        string ProviderName { get; }

        #endregion

        #region Public Methods

        Task<DbConnection> CreateConnectionAsync();

        #endregion
    }
}