using Microsoft.Data.SqlClient;
using System.Data;

namespace Authentication.API.Data
{
    public class DatabaseConnection
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlConnection> GetConnection()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection"));
            await connection.OpenAsync();
            return connection;
        }

        public async Task<DataTable> GetDataTable(string sqlQuery, Dictionary<string, object>? sqlParams)
        {
            var dataTable = new DataTable();

            using (SqlConnection sqlConnection = await GetConnection())
            {
                var com = new SqlCommand(sqlQuery, sqlConnection)
                {
                    CommandTimeout = 600
                };

                if (sqlParams != null && sqlParams.Count > 0)
                    foreach (var param in sqlParams)
                        com.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

                using var reader = await com.ExecuteReaderAsync(); dataTable.Load(reader);
            };

            return dataTable;
        }

        public async Task<int> Insert(string tableName, Dictionary<string, object> sqlParams)
        {
            var columns = string.Join(", ", sqlParams.Keys);
            var parameters = string.Join(", ", sqlParams.Keys.Select(k => "@" + k));

            var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

            using var connection = await GetConnection();
            using var command = new SqlCommand(sql, connection);

            foreach (var param in sqlParams)
            {
                command.Parameters.AddWithValue("@" + param.Key, param.Value ?? DBNull.Value);
            }

            return await command.ExecuteNonQueryAsync(); // Retorna número de linhas afetadas
        }
    }
}
