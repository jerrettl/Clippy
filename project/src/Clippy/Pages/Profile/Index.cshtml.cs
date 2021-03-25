using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clippy.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

        public IList<Bookmark> Bookmarks { get; set; }

        public User ViewingUser { get; set; }

        public User ThisUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string githubId = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            ThisUser = await _context.GetUserByGithubId(githubId);
            if (id == 0)
            {
                ViewingUser = ThisUser;
                id = ThisUser.Id;
            }
            else
            {
                ViewingUser = await _context.GetUserAsync(id);
            }

            if (ThisUser == null || ViewingUser == null)
            {
                return RedirectToPage("/Index");
            }

            Bookmarks = await _context.GetBookmarksByUserIdAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int thisuser, int viewinguser) {
            ThisUser = await _context.GetUserAsync(thisuser);
            ViewingUser = await _context.GetUserAsync(viewinguser);

            if (ThisUser.Subscriptions.Contains(ViewingUser))
            {
                ThisUser.Subscriptions.Remove(ViewingUser);
            }
            else
            {
                ThisUser.Subscriptions.Add(ViewingUser);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Profile/Index", new { id = ViewingUser.Id });
        }
    }
}
