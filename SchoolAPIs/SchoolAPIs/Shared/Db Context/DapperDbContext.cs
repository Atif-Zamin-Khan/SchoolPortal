using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SchoolAPIs.Shared.Db_Context
{
    public class DapperDbContext 
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperDbContext(IConfiguration configuration )
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }


        // Generics Method to return a list ...QueryAsync 
        public async Task<List<T>> QueryAsync<T>(string query, object? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        await connection.OpenAsync();

                    var result = await connection.QueryAsync<T>(query, parameters, commandType: commandType);
                    return result.ToList();
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

        }


        // Generics Methods to return a single Records ...QueryFirstOrDefaultAsync
        public async Task<T> QueryFirstOrDefault<T>(string query, object? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        await connection.OpenAsync();
                    var result = await connection.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: commandType);
                    return result;

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        
        



    }
}
