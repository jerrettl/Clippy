using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Clippy.Pages.Admin.Roles
{
    public class DetailsModel : PageModel
    {
        private ClippyContext _context;

        public DetailsModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) {
            Role = await _context.GetRoleAsync(id);
            if (Role == null)
            {
                TempData["Message"] = $"Role not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var role = await _context.GetRoleAsync(id);

            if (role == null)
                return RedirectToPage("./Index");

            _context.Remove(role);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
