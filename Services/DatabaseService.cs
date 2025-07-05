using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using MiniAccountManagementSystem.Data;
using MiniAccountManagementSystem.Models;

namespace MiniAccountManagementSystem.Services
{
    public class DatabaseService
    {
      
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<T>> ExecuteStoredProcedureAsync<T>(string storedProcedureName, SqlParameter[] parameters, Func<SqlDataReader, T> map)
        {
            var results = new List<T>();
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parameters != null)
                command.Parameters.AddRange(parameters);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                results.Add(map(reader));
            }
            return results;
        }

        public async Task ExecuteStoredProcedureNonQueryAsync(string storedProcedureName, SqlParameter[] parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parameters != null)
                command.Parameters.AddRange(parameters);

            await command.ExecuteNonQueryAsync();
        }
        public async Task<List<Models.Account>> GetAccountsAsync()
        {
            var accounts = new List<Models.Account>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("sp_ManageChartOfAccounts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Action", "SELECT");
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accounts.Add(new Models.Account
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
            return accounts;
        }
        public async Task<(Voucher voucher, List<VoucherEntry> entries)> ExecuteStoredProcedureAsyncMultipleResults(string storedProcedureName, SqlParameter[] parameters)
        {
            Voucher voucher = null!;
            var entries = new List<VoucherEntry>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            using var reader = await command.ExecuteReaderAsync();

            // ✅ First result set: Voucher
            if (await reader.ReadAsync())
            {
                voucher = new Voucher
                {
                    VoucherId = reader.GetInt32(0),
                    VoucherType = reader.GetString(1),
                    VoucherDate = reader.GetDateTime(2),
                    ReferenceNo = reader.GetString(3)
                };
            }

            // ✅ Move to second result set: Voucher Entries
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    entries.Add(new VoucherEntry
                    {
                        AccountId = reader.GetInt32(1),
                        Debit = reader.GetDecimal(2),
                        Credit = reader.GetDecimal(3)
                    });
                }
            }

            return (voucher, entries);
        }

        

        // (Assume this is the end of your DatabaseService class)
    }
}