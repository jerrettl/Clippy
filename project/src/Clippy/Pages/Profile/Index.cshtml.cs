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

        public IList<Bookmark> FavoriteBookmarks { get; set; }

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
            if (id == 0 || ThisUser.Id == id)
            {
                ViewingUser = ThisUser;
                id = ThisUser.Id;
                Bookmarks = await _context.GetBookmarksByUserIdAsync(id);
                FavoriteBookmarks = await _context.GetFavoriteBookmarksByUserIdAsync(id);
            }
            else
            {
                ViewingUser = await _context.GetUserAsync(id);
                Bookmarks = await _context.GetPublicBookmarksByUserIdAsync(id);
                FavoriteBookmarks = await _context.GetPublicFavoriteBookmarksByUserIdAsync(id);
            }

            if (ThisUser == null || ViewingUser == null)
            {
                return RedirectToPage("/Index");
            }


            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int thisuser, int viewinguser) {
            ThisUser = await _context.GetUserAsync(thisuser);
            ViewingUser = await _context.GetUserAsync(viewinguser);

            if (ThisUser.Subscriptions.Contains(ViewingUser))
            {
                ThisUser.Subscriptions.Remove(ViewingUser);
                ViewingUser.Followers.Remove(ThisUser);
            }
            else
            {
                ThisUser.Subscriptions.Add(ViewingUser);
                ViewingUser.Followers.Add(ThisUser);
            }

            _context.AddNotification(new Notification {
                UserId = ThisUser.Id,
                CreateDate = DateTime.Now,
                Text = $"{ThisUser.Name} followed {ViewingUser.Name}!"
            });

            await _context.SaveChangesAsync();
            return RedirectToPage("/Profile/Index", new { id = ViewingUser.Id });
        }
    }
}
