using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.Models;
using MiniAccountManagementSystem.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Identity;

namespace MiniAccountManagementSystem.Pages.ChartOfAccounts
{
    [Authorize(Roles = "Admin,Accountant")]
    public class IndexModel : PageModel
    {
        private readonly DatabaseService _dbService;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(DatabaseService dbService, UserManager<IdentityUser> userManager)
        {
            _dbService = dbService;
            _userManager = userManager;
        }

        public List<TreeNode> Accounts { get; set; }
        public List<UserModel> Users { get; set; } // Changed to UserModel to include Roles

        // New model to hold user data with roles
        public class UserModel
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Roles { get; set; }
        }

        public async Task OnGetAsync()
        {
            // Existing code to fetch accounts (unchanged)
            var accountParameters = new[] { new SqlParameter("@Action", "SELECT") };
            var accounts = await _dbService.ExecuteStoredProcedureAsync("sp_ManageChartOfAccounts", accountParameters, reader => new MiniAccountManagementSystem.Models.Account
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                ParentAccountId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                Balance = reader.GetDecimal(3)
            });
            Accounts = BuildTree(accounts);

            // Modified code to fetch users with roles
            var userParameters = new[] { new SqlParameter("@Action", "SELECT") };
            Users = await _dbService.ExecuteStoredProcedureAsync("sp_ManageUsers", userParameters, reader => new UserModel
            {
                Id = reader.GetString(0),
                UserName = reader.GetString(1),
                Email = reader.GetString(2),
                Roles = reader.IsDBNull(3) ? "None" : reader.GetString(3) // Handle NULL roles
            });
        }

        public async Task<IActionResult> OnGetExportAsync()
        {
            // Existing Excel export code (unchanged)
            var parameters = new[] { new SqlParameter("@Action", "SELECT") };
            var accounts = await _dbService.ExecuteStoredProcedureAsync("sp_ManageChartOfAccounts", parameters, reader => new MiniAccountManagementSystem.Models.Account
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                ParentAccountId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                Balance = reader.GetDecimal(3)
            });

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Accounts");
            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Balance";
            worksheet.Cell(1, 4).Value = "ParentAccountId";
            for (int i = 0; i < accounts.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = accounts[i].Id;
                worksheet.Cell(i + 2, 2).Value = accounts[i].Name;
                worksheet.Cell(i + 2, 3).Value = accounts[i].Balance;
                worksheet.Cell(i + 2, 4).Value = accounts[i].ParentAccountId ?? 0;
            }

            using var stream = new System.IO.MemoryStream();
            workbook.SaveAs(stream);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Accounts.xlsx");
        }

        private List<TreeNode> BuildTree(List<MiniAccountManagementSystem.Models.Account> accounts)
        {
            // Existing tree-building code (unchanged)
            var tree = new List<TreeNode>();
            var lookup = accounts.ToDictionary(a => a.Id, a => new TreeNode
            {
                text = $"{a.Name} (Balance: {a.Balance:C})",
                href = $"/ChartOfAccounts/Edit?id={a.Id}",
                nodes = new List<TreeNode>()
            });

            foreach (var account in accounts)
            {
                if (account.ParentAccountId.HasValue && lookup.ContainsKey(account.ParentAccountId.Value))
                {
                    lookup[account.ParentAccountId.Value].nodes.Add(lookup[account.Id]);
                }
                else
                {
                    tree.Add(lookup[account.Id]);
                }
            }

            return tree;
        }
    }

    public class TreeNode
    {
        public string text { get; set; }
        public string href { get; set; }
        public List<TreeNode> nodes { get; set; }
    }
}