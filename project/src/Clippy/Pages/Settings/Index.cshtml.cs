using Clippy.Data;
using Clippy.Entities;
using Clippy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clippy.Pages.Settings
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

        public string AvatarUrl { get; set; }

        [BindProperty]
        public EditUserModel UserEntity { get; set; }

        public User ThisUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            AvatarUrl = "";
            string githubId = "";
            string name = "";
            string username = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == "urn:github:avatar") AvatarUrl = claim.Value;
                else if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
                else if (claim.Type == ClaimTypes.Name) name = claim.Value;
                else if (claim.Type == "urn:github:login") username = claim.Value;
            }

            ThisUser = await _context.GetUserByGithubId(githubId);
            int userId;
            if (ThisUser != null)
            {
                userId = ThisUser.Id;
            }
            else
            {
                ThisUser = new User
                {
                    Username = username,
                    Name = name,
                    GithubId = githubId,
                    CreateDate = DateTime.Now,
                    AvatarUrl = AvatarUrl
                };

                var dbResponse = _context.AddUser(ThisUser);
                await _context.SaveChangesAsync();
                userId = dbResponse.Entity.Id;
            }

            UserEntity = new EditUserModel {
              Bio = ThisUser.Bio,
              ClippyMode = ThisUser.ClippyMode
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string githubId = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            var existingUser = await _context.GetUserByGithubId(githubId);
            if (existingUser == null)
            {
                return Page();
            }

            existingUser.Bio = UserEntity.Bio;
            existingUser.ClippyMode = UserEntity.ClippyMode;

            _context.Update(existingUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Profile/Index");
        }

        public async Task<IActionResult> OnPostRefreshAsync()
        {
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

            User user = await _context.GetUserByGithubId(githubId);
            if (user == null)
            {
                return RedirectToPage("./Index");
            }

            user.AvatarUrl = avatarUrl;
            user.Username = username;
            user.Name = name;
            
            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Profile/Index");
        }
    }
}
