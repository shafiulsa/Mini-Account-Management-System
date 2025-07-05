using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MiniAccountManagementSystem.Pages.ManageUsers
{
    public class Delete : PageModel
    {
 private readonly UserManager<IdentityUser> _userManager;

        public Delete(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public IdentityUser UserToDelete { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            UserToDelete = await _userManager.FindByIdAsync(id);
            if (UserToDelete == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(UserToDelete.Id);
            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);
            return RedirectToPage("/ChartOfAccounts/Index");
        }
    }
}