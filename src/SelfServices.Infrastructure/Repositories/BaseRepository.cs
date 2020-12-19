using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace SelfServices.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        private string _connectionString { get; }

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<T> GetAsync<T>(string procedure, object filter = null)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            return (await conn.QueryAsync<T>(procedure, filter, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }

        protected async Task<IEnumerable<T>> GetListAsync<T>(string procedure, object filter)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            return (await conn.QueryAsync<T>(procedure, filter, commandType: CommandType.StoredProcedure));
        }

        protected async Task ExecuteAsync(string procedure, object filter)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            await conn.ExecuteAsync(procedure, filter, commandType: CommandType.StoredProcedure);
        }
    }
}