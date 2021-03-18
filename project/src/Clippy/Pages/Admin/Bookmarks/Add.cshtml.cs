using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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

        public List<SelectListItem> Users { get; set; }

        public async Task OnGet() {
            var users = await _context.GetUsersAsync();
            Users = users.Select(u => new SelectListItem(u.Name, u.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            DateTime now = DateTime.UtcNow;

            var bookmark = new Bookmark();
            bookmark.Tags = new List<Tag>();

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
            var existingResource = await _context.GetResourceByLocationAsync(BookmarkEntity.Location);

            // If it is found, take that existing resource and use its ID with the new bookmark.
            if (existingResource != null)
            {
                bookmark.ResourceId = existingResource.Id;
            }
            else
            {
                // If it isn't found, make a new resource.
                var metadata = new Dictionary<string,string>();
                if (!string.IsNullOrWhiteSpace(BookmarkEntity.Title))
                    metadata.Add("Title", BookmarkEntity.Title);

                if (!string.IsNullOrWhiteSpace(BookmarkEntity.Description))
                    metadata.Add("Description", BookmarkEntity.Description);

                var resource = new Resource {
                    Location = BookmarkEntity.Location,
                    Metadata = metadata,
                    CreateDate = now
                };

                // Write the resource to the database and use the ID that ends up being used.
                var dbResponse = _context.AddResource(resource);
                await _context.SaveChangesAsync();
                bookmark.ResourceId = dbResponse.Entity.Id;
            }

            if (BookmarkEntity.UserId == 0)
            {
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
            } else
            {
                bookmark.UserId = BookmarkEntity.UserId;
            }

            // Add Tags
            if (!string.IsNullOrWhiteSpace(BookmarkEntity.Tags))
            {
                // TODO: Check for uniqueness
                var tags = BookmarkEntity.Tags.Split(',');
                foreach(var tag in tags) {
                    bookmark.Tags.Add(new Tag {TagName = tag});
                }
            }

            bookmark.CreateDate = now;

            _context.AddBookmark(bookmark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
