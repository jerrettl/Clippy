using Clippy.Data;
using System.Security.Claims;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Clippy.Pages.Following
{
    public class FollowersModel : PageModel
    {
        private ClippyContext _context;

        public FollowersModel(ClippyContext context)
        {
            _context = context;
        }

        public User ThisUser { get; set; }

        public User UserBeingUnfollowed { get; set; }

        public async Task OnGetAsync()
        {
            string githubId = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            ThisUser = await _context.GetUserByGithubId(githubId);
        }

        public async Task<IActionResult> OnPostAsync(int thisuser, int viewinguser)
        {
            ThisUser = await _context.GetUserAsync(thisuser);
            UserBeingUnfollowed = await _context.GetUserAsync(viewinguser);

            if (ThisUser.Subscriptions.Contains(UserBeingUnfollowed))
            {
                ThisUser.Subscriptions.Remove(UserBeingUnfollowed);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Following/Index");
        }
    }
}
