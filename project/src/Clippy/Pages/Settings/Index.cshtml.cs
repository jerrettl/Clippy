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

            User user = await _context.GetUserByGithubId(githubId);
            int userId;
            if (user != null)
            {
                userId = user.Id;
            }
            else
            {
                user = new User
                {
                    Username = username,
                    Name = name,
                    GithubId = githubId,
                    CreateDate = DateTime.Now
                };

                var dbResponse = _context.AddUser(user);
                await _context.SaveChangesAsync();
                userId = dbResponse.Entity.Id;
            }

            UserEntity = new EditUserModel {
              Bio = user.Bio
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

            _context.Update(existingUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Profile/Index");
        }
    }
}
