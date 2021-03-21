using System;
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
                Bio = user.Bio
            };

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

            _context.Update(existingUser);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"The user, {existingUser.Username}, was successfully updated.";

            _logger.LogWarning(AdminLoggingEvents.UpdateUserEvent, $"New user updated: {existingUser.Username}.");

            return RedirectToPage("./Index");
        }
    }
}
