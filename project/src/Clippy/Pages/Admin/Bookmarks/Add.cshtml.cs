using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Bookmarks
{
    public class AddModel : PageModel
    {
        private ClippyContext _context;

        public AddModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public AddBookmarkModel BookmarkEntity { get; set; }

        public void OnGet() {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            DateTime now = DateTime.UtcNow;

            var bookmark = new Bookmark();

            // Grab information about the user. This will be used to associate user
            // information with the new bookmark.
            string githubId = "";
            string name = "";
            string username = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
                else if (claim.Type == ClaimTypes.Name) name = claim.Value;
                else if (claim.Type == "urn:github:login") username = claim.Value;
            }

            // Using the bookmark URL, find the corresponding resource from the database.
            var existingResource = await _context.GetResourceByLocationAsync(BookmarkEntity.Url);

            // If it is found, take that existing resource and use its ID with the new bookmark.
            if (existingResource != null)
            {
                bookmark.ResourceId = existingResource.Id;
            }
            else
            {
                // If it isn't found, make a new resource.
                var metadata = new Dictionary<string,string>();
                metadata.Add("Title", BookmarkEntity.Title ?? null);

                var resource = new Resource {
                    Location = BookmarkEntity.Url,
                    Metadata = metadata,
                    CreateDate = now
                };

                // Write the resource to the database and use the ID that ends up being used.
                var dbResponse = _context.AddResource(resource);
                await _context.SaveChangesAsync();
                bookmark.ResourceId = dbResponse.Entity.Id;
            }

            // Repeat the process with adding a resource with adding a user.
            var existingUser = await _context.GetUserByGithubId(githubId);

            if (existingUser != null)
            {
                bookmark.UserId = existingUser.Id;
            }
            else
            {
                var user = new User {
                    Username = username,
                    Name = name,
                    GithubId = githubId,
                    CreateDate = now
                };

                var dbResponse = _context.AddUser(user);
                await _context.SaveChangesAsync();
                bookmark.UserId = dbResponse.Entity.Id;
            }

            bookmark.CreateDate = now;
            
            _context.AddBookmark(bookmark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
