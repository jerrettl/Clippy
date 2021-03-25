using Clippy.Data;
using System.Security.Claims;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clippy.Pages.Following
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context)
        {
            _context = context;
        }

        public User ThisUser { get; set; }

        public async Task OnGetAsync()
        {
            string githubId = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            ThisUser = await _context.GetUserByGithubId(githubId);
        }
    }
}
