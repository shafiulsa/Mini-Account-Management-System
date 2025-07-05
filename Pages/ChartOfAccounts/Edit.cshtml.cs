using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MiniAccountManagementSystem.Services;

namespace MiniAccountManagementSystem.Pages.ChartOfAccounts
{
    [Authorize(Roles = "Admin")]
    public class Edit : PageModel
    {
        private readonly DatabaseService _dbService;
        public Edit(DatabaseService dbService) => _dbService = dbService;

        [BindProperty]
        public Models.Account Account { get; set; }
        public List<Models.Account> AllAccounts { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var getParams = new[] {
                new SqlParameter("@Action", "SELECT_BY_ID"),
                new SqlParameter("@Id", id)
            };

            var result = await _dbService.ExecuteStoredProcedureAsync("sp_ManageChartOfAccounts", getParams, reader => new Models.Account
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                ParentAccountId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                Balance = reader.GetDecimal(3)
            });

            Account = result.FirstOrDefault();
            if (Account == null) return NotFound();

            var allParams = new[] { new SqlParameter("@Action", "SELECT") };
            AllAccounts = await _dbService.ExecuteStoredProcedureAsync("sp_ManageChartOfAccounts", allParams, reader => new Models.Account
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                ParentAccountId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                Balance = reader.GetDecimal(3)
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var updateParams = new[]
            {
                new SqlParameter("@Action", "UPDATE"),
                new SqlParameter("@Id", Account.Id),
                new SqlParameter("@Name", Account.Name),
                new SqlParameter("@ParentAccountId", Account.ParentAccountId ?? (object)DBNull.Value),
                new SqlParameter("@Balance", Account.Balance)
            };

            await _dbService.ExecuteStoredProcedureNonQueryAsync("sp_ManageChartOfAccounts", updateParams);
            return RedirectToPage("Index");
        }
    }
   
}
