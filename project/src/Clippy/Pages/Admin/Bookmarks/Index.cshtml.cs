using System.Collections.Generic;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Bookmarks
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

         public IList<Bookmark> Bookmarks { get; set; }

        public async void OnGetAsync() {
            Bookmarks = await _context.GetBookmarksAsync();
        }
    }
}
