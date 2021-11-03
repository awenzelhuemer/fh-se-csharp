using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Common
{
    public class AdoTemplate
    {
        #region Private Fields

        private IConnectionFactory connectionFactory;

        #endregion

        #region Public Constructors

        public AdoTemplate(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, RowMapper<T> rowMapper, params QueryParameter[] parameters)
        {
            await using DbConnection connection = await connectionFactory.CreateConnectionAsync();

            await using DbCommand command = connection.CreateCommand();
            AddParameters(command, parameters);
            command.CommandText = sql;

            IList<T> items = new List<T>();
            await using DbDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                items.Add(rowMapper(reader));
            }
            return items;
        }

        private void AddParameters(DbCommand command, QueryParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                DbParameter dbParam = command.CreateParameter();
                dbParam.ParameterName = p.Name;
                dbParam.Value = p.Value;
                command.Parameters.Add(dbParam);
            }
        }

        public async Task<T> QuerySingleAsync<T>(string sql, RowMapper<T> rowMapper, params QueryParameter[] parameters)
        {
            return (await QueryAsync(sql, rowMapper, parameters)).SingleOrDefault();
        }

        public async Task<int> ExecuteAsync(string sql, params QueryParameter[] parameters)
        {
            using DbConnection connection = await connectionFactory.CreateConnectionAsync();

            using DbCommand command = connection.CreateCommand();
            AddParameters(command, parameters);
            command.CommandText = sql;

            return await command.ExecuteNonQueryAsync();
        }

        // Hint for insert command
        // command Execute Scalar(
        // <insert-command>; select scope_id
        // convert.ToInt32(...)

        #endregion
    }
}