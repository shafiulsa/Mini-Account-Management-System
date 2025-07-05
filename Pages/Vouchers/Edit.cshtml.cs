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
    public class EditModel : PageModel
    {
        private readonly DatabaseService _dbService;

        public EditModel(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        [BindProperty]
        public Voucher Voucher { get; set; }

        [BindProperty]
        public List<VoucherEntry> Entries { get; set; }

        public List<Models.Account> Accounts { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Accounts = await _dbService.GetAccountsAsync();
            
            var (voucher, entries) = await _dbService.ExecuteStoredProcedureAsyncMultipleResults(
                "sp_GetVoucherDetails",
                new Microsoft.Data.SqlClient.SqlParameter[] { new("@VoucherId", id) });
            
            if (voucher == null)
            {
                return NotFound();
            }

            Voucher = voucher;
            Entries = entries;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Accounts = await _dbService.GetAccountsAsync();
                return Page();
            }

            // Update voucher
            var voucherParams = new SqlParameter[]
            {
                new("@VoucherId", Voucher.VoucherId),
                new("@VoucherType", Voucher.VoucherType),
                new("@VoucherDate", Voucher.VoucherDate),
                new("@ReferenceNo", Voucher.ReferenceNo)
            };
            await _dbService.ExecuteStoredProcedureNonQueryAsync("sp_UpdateVoucher", voucherParams);

            // Delete existing entries
            await _dbService.ExecuteStoredProcedureNonQueryAsync(
                "sp_DeleteVoucherEntries",
                new SqlParameter[] { new("@VoucherId", Voucher.VoucherId) });

            // Add updated entries
            foreach (var entry in Entries)
            {
                var entryParams = new SqlParameter[]
                {
                    new("@VoucherId", Voucher.VoucherId),
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