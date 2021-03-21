using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Users
{
    public class AddModel : PageModel
    {
        private ClippyContext _context;

        public AddModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public AddUserModel UserEntity { get; set; }

        public void OnGet() {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingUser = await _context.GetUserByUsernameAsync(UserEntity.Username);
            if (existingUser != null) {
                ModelState.AddModelError("Username", $"Username is already taken: {existingUser.Username}.");
            }

            // Add Roles
            var roles = new List<Role>();
            if (!string.IsNullOrWhiteSpace(UserEntity.Roles))
            {
                var rolenames = UserEntity.Roles.Split(',');
                foreach(var rolename in rolenames) {
                    if (string.IsNullOrWhiteSpace(rolename))
                        continue;

                    var r = await _context.GetRoleByNameAsync(rolename.Trim());
                    if (r == null)
                    {
                        ModelState.AddModelError("Roles", $"{rolename} does not exist.");
                        continue;
                    }

                    roles.Add(r);
                }
            }

            // Add Subscriptions
            var subscriptions = new List<User>();
            if (!string.IsNullOrWhiteSpace(UserEntity.Subscriptions))
            {
                var usernames = UserEntity.Subscriptions.Split(',');
                foreach(var username in usernames) {
                    if (string.IsNullOrWhiteSpace(username))
                        continue;

                    var account = await _context.GetUserByUsernameAsync(username.Trim());
                    if (account == null)
                    {
                        ModelState.AddModelError("Subscriptions", $"{username} does not exist.");
                        continue;
                    }

                    subscriptions.Add(account);
                }
            }

            if (!ModelState.IsValid)
                return Page();

            var user = new User
            {
                Username = UserEntity.Username,
                Name = UserEntity.Name,
                Bio = UserEntity.Bio,
                CreateDate = DateTime.UtcNow,
                Roles = roles,
                Subscriptions = subscriptions,
                Followers = new List<User>()
            };

            _context.AddUser(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"The user, {user.Username}, was successfully added.";

            return RedirectToPage("./Index");
        }
    }
}
