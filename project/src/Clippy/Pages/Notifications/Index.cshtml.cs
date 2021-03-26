using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clippy.Pages.Notifications
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context)
        {
            _context = context;
        }

        public IList<Bookmark> Bookmarks { get; set; }

        public IList<User> Users { get; set; }

        public User ThisUser { get; set; }

        public IList<Notification> Notifications { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string githubId = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            Users = await _context.GetUsersAsync();

            ThisUser = await _context.GetUserByGithubId(githubId);
            if (ThisUser != null)
            {
                Notifications = await _context.GetNotificationsByUser(ThisUser.Id);
            }
            
            return Page();
        }
    }
}
