using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace Clippy.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

        public string AvatarUrl { get; set; }

        public void OnGetAsync()
        {
            AvatarUrl = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == "urn:github:avatar") AvatarUrl = claim.Value;
            }

        }
    }
}
