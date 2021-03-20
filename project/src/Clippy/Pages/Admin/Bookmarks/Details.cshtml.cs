using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Clippy.Pages.Admin.Bookmarks
{
    public class DetailsModel : PageModel
    {
        private ClippyContext _context;

        public DetailsModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public Bookmark Bookmark { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) {
            Bookmark = await _context.GetBookmarkAsync(id);
            if (Bookmark == null)
                return RedirectToPage("./Index");

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var bookmark = await _context.GetBookmarkAsync(id);

            _context.Remove(bookmark);

            await _context.SaveChangesAsync();

            TempData["Message"] = $"Bookmark successfully deleted. Id = {id}.";

            return RedirectToPage("./Index");
        }
    }
}
