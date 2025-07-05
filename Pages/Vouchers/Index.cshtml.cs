using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MiniAccountManagementSystem.Services;

namespace MiniAccountManagementSystem.Pages.Vouchers

{
    [Authorize(Roles = "Accountant,Viewer")]
    public class Index : PageModel  // Changed from 'Index' to 'IndexModel'
    {
        private readonly DatabaseService _dbService;

        public Index(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Models.Voucher> Vouchers { get; set; } = new();

        public async Task OnGetAsync()
        {
            Vouchers = await _dbService.ExecuteStoredProcedureAsync(
                "sp_GetVouchers", 
                null, 
                reader => new Models.Voucher
                {
                    VoucherId = reader.GetInt32(0),
                    VoucherType = reader.GetString(1),
                    VoucherDate = reader.GetDateTime(2),
                    ReferenceNo = reader.GetString(3)
                });
        }
    }
}