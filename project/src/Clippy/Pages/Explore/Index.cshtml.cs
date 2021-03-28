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

        public bool ClippyMode { get; set; }

        public async Task OnGetAsync()
        {
            Bookmarks =  await _context.GetPublicBookmarksAsync();

            string githubId = null;
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            if (githubId == null)
            {
                ClippyMode = false;
            }
            else
            {
                User user = await _context.GetUserByGithubId(githubId);
                ClippyMode = user.ClippyMode;
            }
        }
    }
}
