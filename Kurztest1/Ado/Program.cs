using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ado
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await QueryAsync("select * from test where name = @name", MapEntity, new SqlParameter { ParameterName = "name", Value = "Test" });
        }

        private static dynamic MapEntity(IDataRecord record)
        {
            dynamic obj = new object();
            obj.Name = record["name"];
            return obj;
        }

        public delegate T RowMapper<T>(IDataRecord record);

        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, RowMapper<T> rowMapper, params DbParameter[] parameters)
        {
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
            var factory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");

            using DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = "...";
            await connection.OpenAsync();

            await using DbCommand command = connection.CreateCommand();
            command.Parameters.AddRange(parameters);
            command.CommandText = sql;

            IList<T> items = new List<T>();
            
            // read
            await using DbDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                items.Add(rowMapper(reader));
            }

            // write
            var rowCount = await command.ExecuteNonQueryAsync();

            return items;
        }
    }
}
