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
    public class Delete : PageModel
    {

         private readonly DatabaseService _dbService;
        public Delete(DatabaseService dbService) => _dbService = dbService;

        [BindProperty]
        public Models.Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@Action", "SELECT_BY_ID"),
                new SqlParameter("@Id", id)
            };

            var result = await _dbService.ExecuteStoredProcedureAsync("sp_ManageChartOfAccounts", parameters, reader => new Models.Account
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                ParentAccountId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                Balance = reader.GetDecimal(3)
            });

            Account = result.FirstOrDefault();
            return Account == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var deleteParams = new[]
            {
                new SqlParameter("@Action", "DELETE"),
                new SqlParameter("@Id", Account.Id)
            };

            await _dbService.ExecuteStoredProcedureNonQueryAsync("sp_ManageChartOfAccounts", deleteParams);
            return RedirectToPage("Index");
        }


    }
}