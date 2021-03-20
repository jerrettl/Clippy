using System;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Roles
{
    public class EditModel : PageModel
    {
        private ClippyContext _context;

        public EditModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public EditRoleModel Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var role = await _context.GetRoleAsync(id);
            if (role == null)
            {
                TempData["Message"] = $"Role not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            Role = new EditRoleModel {
                Name = role.Name
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            var existingRole = await _context.GetRoleAsync(id);
            if (existingRole == null)
            {
                TempData["Message"] = $"Role not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            if (existingRole.Name != Role.Name) {
                var existingName = await _context.GetRoleByNameAsync(Role.Name);
                if (existingName != null)
                    ModelState.AddModelError("Name", $"This name is already taken.");
            }

            if (!ModelState.IsValid)
                return Page();

            existingRole.Name = Role.Name;

            _context.Update(existingRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
