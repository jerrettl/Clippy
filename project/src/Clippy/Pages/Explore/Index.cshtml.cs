using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace Clippy.Pages.Explore
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

        public string AvatarUrl { get; set; }

        public IList<Bookmark> Bookmarks { get; set; }

        public async void OnGetAsync()
        {
            AvatarUrl = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == "urn:github:avatar") AvatarUrl = claim.Value;
            }

            Bookmarks = await _context.GetBookmarksAsync();
        }
    }
}
