using System.Data.SqlClient;
using Dapper;

namespace Torc.Assessments.BookSearch.Server.DAL
{
    public interface ISqlServerConnector
    {
        IEnumerable<TEntity> RunQuery<TEntity>(string query, object? parameters = null);
    }

    public class SqlServerConnector : ISqlServerConnector
    {
        private readonly string _connectionString;
        public SqlServerConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TEntity> RunQuery<TEntity>(string query, object? parameters = null)
        {
            using var connection =  new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<TEntity>(query, parameters);
        }
    }
}
