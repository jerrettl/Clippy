using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Clippy.Pages.Admin.Users
{
    public class DetailsModel : PageModel
    {
        private ClippyContext _context;
        private ILogger _logger;

        public DetailsModel(ClippyContext context, ILogger<DetailsModel> logger) {
            _context = context;
            _logger = logger;
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

            TempData["Message"] = $"The user, {user.Username}, was successfully deleted.";

            _logger.LogWarning(AdminLoggingEvents.RemoveUserEvent, $"User removed: {user.Username}.");

            return RedirectToPage("./Index");
        }

    }
}
