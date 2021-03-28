using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Security.Claims;

namespace Clippy.Pages.Bookmarks
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

        public IList<Bookmark> Bookmarks { get; set; }

        public User ThisUser { get; set; }

        public async void OnGetAsync()
        {
            DateTime now = DateTime.Now;
            string githubId = "";
            string name = "";
            string username = "";
            string avatarUrl = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
                else if (claim.Type == ClaimTypes.Name) name = claim.Value;
                else if (claim.Type == "urn:github:login") username = claim.Value;
                else if (claim.Type == "urn:github:avatar") avatarUrl = claim.Value;
            }

            ThisUser = await _context.GetUserByGithubId(githubId);
            int userId;
            if (ThisUser != null)
            {
                userId = ThisUser.Id;
            }
            else
            {
                ThisUser = new User {
                    Username = username,
                    Name = name,
                    GithubId = githubId,
                    CreateDate = now,
                    AvatarUrl = avatarUrl
                };

                var dbResponse = _context.AddUser(ThisUser);
                await _context.SaveChangesAsync();
                userId = dbResponse.Entity.Id;
            }

            Bookmarks = await _context.GetBookmarksByUserIdAsync(userId);
        }
    }
}
