using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Clippy.Pages.Admin.Roles
{
    public class AddModel : PageModel
    {
        private ClippyContext _context;

        public AddModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public AddRoleModel Role { get; set; }

        public void OnGet() {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var existingRole = await _context.GetRoleByNameAsync(Role.Name);
            if (existingRole != null)
            {
                ModelState.AddModelError("Name", $"Name is already taken.");
            };

            if (!ModelState.IsValid)
                return Page();

            var role = new Role
            {
                Name = Role.Name
            };

            _context.AddRole(role);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
