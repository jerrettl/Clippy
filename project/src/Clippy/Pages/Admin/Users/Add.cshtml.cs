using System;
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

            if (!ModelState.IsValid)
                return Page();

            var user = new User
            {
                Username = UserEntity.Username,
                Name = UserEntity.Name,
                CreateDate = DateTime.UtcNow
            };

            _context.AddUser(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
