using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace Clippy.Pages.Admin.Users
{
    public class DetailsModel : PageModel
    {
        private ClippyContext _context;

        public DetailsModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public User UserEntity { get; set; }

        public bool UnitTesting { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int id) {
            UserEntity = await _context.GetUserAsync(id);
            if (UserEntity == null)
            {
                TempData["Message"] = $"User not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _context.GetUserAsync(id);

            if (user == null)
            {
                TempData["Message"] = $"User not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            if (!UnitTesting)
            {
                string currentUsername = User.Claims.First(c => c.Type == "urn:github:login").Value;

                if (currentUsername.Equals(user.Username))
                {
                    TempData["Message"] = "You cannot delete yo-self!";
                    return RedirectToPage("./Index");
                }
            }

            _context.Remove(user);

            await _context.SaveChangesAsync();

            TempData["Message"] = $"User successfully deleted. Id = {id}.";

            return RedirectToPage("./Index");
        }

    }
}
