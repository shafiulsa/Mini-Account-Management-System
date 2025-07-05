using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MiniAccountManagementSystem.Services;

namespace MiniAccountManagementSystem.Pages.ChartOfAccounts
{
    public class View : PageModel
    {
        private readonly DatabaseService _dbService;
        public View(DatabaseService dbService) => _dbService = dbService;

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
    }
}