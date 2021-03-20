using System;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Helpers;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private ClippyContext _context;

        public EditModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public EditUserModel UserEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _context.GetUserAsync(id);
            if (user == null)
                return RedirectToPage("./Index");

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
                return RedirectToPage("./Index");

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

            return RedirectToPage("./Index");
        }
    }
}
