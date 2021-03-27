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

        public List<SelectListItem> Resources { get; set; }
        public List<SelectListItem> Users { get; set; }

        public async Task OnGet() {
            var resources = await _context.GetResourcesAsync();
            Resources = new List<SelectListItem>();
            foreach(var resource in resources) {
                if (resource.Metadata.ContainsKey("Title"))
                {
                    Resources.Add(new SelectListItem(resource.Metadata["Title"], resource.Id.ToString()));
                } else
                {
                    Resources.Add(new SelectListItem(resource.Location, resource.Id.ToString()));
                }
            }

            var users = await _context.GetUsersAsync();
            Users = users.Select(u => new SelectListItem(u.Name, u.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var resource = await _context.GetResourceAsync(BookmarkEntity.ResourceId);
            if (resource == null) {
                ModelState.AddModelError("ResourceId", "Resource does not exist.");
            }

            var user = await _context.GetUserAsync(BookmarkEntity.UserId);
            if (user == null) {
                ModelState.AddModelError("UserId", "User does not exist.");
            }

            if (!ModelState.IsValid)
                return Page();

            var bookmark = new Bookmark();
            bookmark.Title = BookmarkEntity.Title;
            bookmark.Resource = resource;
            bookmark.User = user;
            bookmark.CreateDate = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(BookmarkEntity.Tags))
            {
                // TODO: Check for uniqueness
                var tags = BookmarkEntity.Tags.Split(',');
                foreach(var tag in tags) {
                    if (!string.IsNullOrWhiteSpace(tag))
                        bookmark.Tags.Add(new Tag {TagName = tag});
                }
            }

            _context.AddBookmark(bookmark);

            await _context.SaveChangesAsync();

            TempData["Message"] = "Bookmark successfully added.";

            return RedirectToPage("./Index");
        }
    }
}
