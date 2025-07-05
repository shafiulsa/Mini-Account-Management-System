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

namespace MiniAccountManagementSystem.Pages.Vouchers
{
    [Authorize(Roles = "Accountant")]
    public class DeleteModel : PageModel
    {
        private readonly DatabaseService _dbService;

        public DeleteModel(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public int VoucherId { get; set; }
        public string VoucherType { get; set; }
        public string ReferenceNo { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var result = await _dbService.ExecuteStoredProcedureAsync(
                "sp_GetVoucherBasicInfo",
                new SqlParameter[] { new("@VoucherId", id) },
                reader => new {
                    VoucherId = reader.GetInt32(0),
                    VoucherType = reader.GetString(1),
                    ReferenceNo = reader.GetString(2)
                });

            if (result.Count == 0)
            {
                return NotFound();
            }

            VoucherId = result[0].VoucherId;
            VoucherType = result[0].VoucherType;
            ReferenceNo = result[0].ReferenceNo;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _dbService.ExecuteStoredProcedureNonQueryAsync(
                "sp_DeleteVoucher",
                new SqlParameter[] { new("@VoucherId", id) });

            return RedirectToPage("./Index");
        }
    }
}