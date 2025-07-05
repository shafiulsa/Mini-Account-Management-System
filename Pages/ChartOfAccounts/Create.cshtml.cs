using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MiniAccountManagementSystem.Models;
using MiniAccountManagementSystem.Services;

namespace MiniAccountManagementSystem.Pages.ChartOfAccounts
{
    [Authorize(Roles = "Admin")]
    public class Create : PageModel
    {

  private readonly DatabaseService _dbService;
        public Create(DatabaseService dbService) => _dbService = dbService;

        [BindProperty]
        public Models.Account Account { get; set; }
        public List<Models.Account> AllAccounts { get; set; }

        public async Task OnGetAsync()
        {
            var param = new[] { new SqlParameter("@Action", "SELECT") };
            AllAccounts = await _dbService.ExecuteStoredProcedureAsync("sp_ManageChartOfAccounts", param, reader => new Models.Account
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                ParentAccountId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                Balance = reader.GetDecimal(3)
            });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var parameters = new[]
            {
                new SqlParameter("@Action", "INSERT"),
                new SqlParameter("@Name", Account.Name),
                new SqlParameter("@ParentAccountId", Account.ParentAccountId ?? (object)DBNull.Value),
                new SqlParameter("@Balance", Account.Balance)
            };
            await _dbService.ExecuteStoredProcedureNonQueryAsync("sp_ManageChartOfAccounts", parameters);
            return RedirectToPage("Index");
        }


    }
}