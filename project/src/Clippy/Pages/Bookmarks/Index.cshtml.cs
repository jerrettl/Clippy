using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Clippy.Pages.Bookmarks
{
    public class IndexModel : PageModel
    {
        public string AvatarUrl { get; set; }

        public void OnGet()
        {
            AvatarUrl = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == "urn:github:avatar") AvatarUrl = claim.Value;
            }
        }
    }
}
