using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DataAccess
{
    public class DapperContext
    {
        private readonly DbConnectionOptions options;
        //private readonly ILogRepository logRepos;

        public DapperContext(IOptions<DbConnectionOptions> options)
        {
            if (string.IsNullOrWhiteSpace(options.Value.ConnectionString))
            {
                throw new ArgumentException("ConnectionString must be not be empty");
            }

            this.options = options.Value;
        }

        public async Task<IEnumerable<T>> QuerySPAsync<T>(string name, DynamicParameters? parameters = null, DbTransaction? transaction = null, int? commandTimeout = null)
        {
            await using var connection = new SqlConnection(options.ConnectionString);
            await connection.OpenAsync();

            return await connection.QueryAsync<T>(
                sql: name,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: transaction,
                commandTimeout: commandTimeout ?? options.CommandTimeout
            );
        }
        public async Task<T?> QuerySPFirstAsync<T>(string name, DynamicParameters parameters, DbTransaction? transaction = null, int? commandTimeout = null)
        {
            await using var connection = new SqlConnection(options.ConnectionString);
            await connection.OpenAsync();

            return await connection.QueryFirstOrDefaultAsync<T>(
                sql: name,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: transaction,
                commandTimeout: commandTimeout ?? options.CommandTimeout
            );
        }
        public async Task ExecSPAsync(string name, DynamicParameters parameters, DbTransaction? transaction = null, int? commandTimeout = null, bool log = false)
        {
            var commandDefinition = new CommandDefinition(
                name,
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: transaction,
                commandTimeout: commandTimeout ?? options.CommandTimeout
            );


            if (transaction == null)
            {
                await using var connection = new SqlConnection(options.ConnectionString);
                await Exec(connection);
            }
            else
            {
                await Exec(transaction.Connection!);
            }

            async Task Exec(IDbConnection connection)
            {
                string? result = null;

                try
                {
                    await connection.ExecuteAsync(commandDefinition);
                }
                catch (Exception ex)
                {
                    string? message = ex.Message ?? ex.InnerException?.Message;
                    result = string.IsNullOrEmpty(message) ? "Error" : message;
                    throw;
                }
                finally
                {
                }
            }

        }


        public async Task<DbConnection> OpenConnectionAsync()
        {
            var connection = new SqlConnection(options.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
