using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace Clippy.Pages.Explore
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

        public IList<Bookmark> Bookmarks { get; set; }

        public User ThisUser { get; set; }

        public async Task OnGetAsync()
        {
            Bookmarks =  await _context.GetPublicBookmarksAsync();

            string githubId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            ThisUser = await _context.GetUserByGithubId(githubId);
        }
    }
}
