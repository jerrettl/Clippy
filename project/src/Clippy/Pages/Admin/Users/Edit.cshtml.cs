using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Helpers;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Clippy.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private ClippyContext _context;
        private ILogger _logger;

        public EditModel(ClippyContext context, ILogger<EditModel> logger) {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public EditUserModel UserEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _context.GetUserAsync(id);
            if (user == null)
            {
                TempData["Message"] = $"User not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            UserEntity = new EditUserModel {
                Username = user.Username,
                Name = user.Name,
                Bio = user.Bio,
                AvatarUrl = user.AvatarUrl
            };

            int i = 0;
            var sb = new StringBuilder();
            foreach(var role in user.Roles) {
                if (i != 0)
                    sb.Append(",");
                sb.Append(role.Name);
                i++;
            }

            UserEntity.Roles = sb.ToString();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            var existingUser = await _context.GetUserAsync(id);
            if (existingUser == null)
            {
                TempData["Message"] = $"User not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            if (existingUser.Username != UserEntity.Username) {
                var existingUsername = await _context.GetUserByUsernameAsync(UserEntity.Username);
                if (existingUsername != null)
                    ModelState.AddModelError("Username", $"This username is already taken.");
            }

            if (!ModelState.IsValid)
                return Page();

            existingUser.Username = UserEntity.Username;
            existingUser.Name = UserEntity.Name;
            existingUser.Bio = UserEntity.Bio;
            existingUser.AvatarUrl = UserEntity.AvatarUrl;

            // Add Roles - Delete existing and start over
            existingUser.Roles.Clear();

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
                    };

                    roles.Add(r);
                }
            }

            existingUser.Roles = roles;

            _context.Update(existingUser);

            await _context.SaveChangesAsync();

            TempData["Message"] = $"The user, {existingUser.Username}, was successfully updated.";

            _logger.LogWarning(AdminLoggingEvents.UpdateUserEvent, $"New user updated: {existingUser.Username}.");

            return RedirectToPage("./Index");
        }
    }
}
