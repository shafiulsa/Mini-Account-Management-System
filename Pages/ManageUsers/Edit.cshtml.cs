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
    public class Edit : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Edit(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public IdentityUser UserToEdit { get; set; }
        [BindProperty]
        public string SelectedRole { get; set; }
        public List<string> AllRoles { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            UserToEdit = await _userManager.FindByIdAsync(id);
            if (UserToEdit == null) return NotFound();

            AllRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            var roles = await _userManager.GetRolesAsync(UserToEdit);
            SelectedRole = roles.FirstOrDefault();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = await _userManager.FindByIdAsync(UserToEdit.Id);
            if (user == null) return NotFound();

            user.UserName = UserToEdit.UserName;
            user.Email = UserToEdit.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return Page();

            // Update role
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!string.IsNullOrEmpty(SelectedRole))
                await _userManager.AddToRoleAsync(user, SelectedRole);

            return RedirectToPage("/ChartOfAccounts/Index");
        }
    }
}