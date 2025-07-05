using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MiniAccountManagementSystem.Pages.Account
{
    public class Logout : PageModel
    {
private readonly SignInManager<IdentityUser> _signInManager;

        public Logout(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage(returnUrl ?? "/Index");
        }
    }
}