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

namespace MiniAccountManagementSystem.Pages.Vouchers
{
    [Authorize(Roles = "Accountant")]
    public class CreateModel : PageModel
    {
        private readonly DatabaseService _dbService;

        public CreateModel(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        [BindProperty]
        public Voucher Voucher { get; set; }

        [BindProperty]
        public List<VoucherEntry> Entries { get; set; } = new List<VoucherEntry>();

        public List<Models.Account> Accounts { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Accounts = await _dbService.GetAccountsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Accounts = await _dbService.GetAccountsAsync();
                return Page();
            }

            var parameters = new SqlParameter[]
            {
                new("@VoucherType", Voucher.VoucherType),
                new("@VoucherDate", Voucher.VoucherDate),
                new("@ReferenceNo", Voucher.ReferenceNo)
            };

            // Execute stored procedure to create voucher
            var (createdVoucher, _) = await _dbService.ExecuteStoredProcedureAsyncMultipleResults(
                "sp_CreateVoucher",
                parameters);

            // Add entries
            foreach (var entry in Entries)
            {
                var entryParams = new SqlParameter[]
                {
                    new("@VoucherId", createdVoucher.VoucherId),
                    new("@AccountId", entry.AccountId),
                    new("@Debit", entry.Debit),
                    new("@Credit", entry.Credit)
                };
                await _dbService.ExecuteStoredProcedureNonQueryAsync("sp_AddVoucherEntry", entryParams);
            }

            return RedirectToPage("./Index");
        }
    }
}