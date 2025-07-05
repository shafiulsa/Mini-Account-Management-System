using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MiniAccountManagementSystem.Pages.Account
{
       
    public class Register : PageModel
    {

            private readonly UserManager<IdentityUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Register(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            [BindProperty]
            public InputModel Input { get; set; }

            public class InputModel
            {
                public string Email { get; set; }
                public string Password { get; set; }
                public string ConfirmPassword { get; set; }
                public string Role { get; set; }
            }

            public async Task<IActionResult> OnPostAsync()
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                        return RedirectToPage("/Index");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return Page();
            }
        

    }
    }