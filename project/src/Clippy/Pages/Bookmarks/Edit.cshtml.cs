using Clippy.Data;
using Clippy.Entities;
using Clippy.Helpers;
using Clippy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clippy.Pages.Bookmarks
{
    public class EditModel : PageModel
    {
        private ClippyContext _context;

        public EditModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public EditBookmarkModel Bookmark { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string githubId = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            User user = await _context.GetUserByGithubId(githubId);
            Bookmark bookmark = await _context.GetBookmarkAsync(id);
            if (user == null || bookmark == null || !user.Id.Equals(bookmark.UserId))
            {
                return RedirectToPage("./Manage");
            }

            Bookmark = new EditBookmarkModel
            {
                Id = bookmark.Id,
                Title = bookmark.Title ?? "",
                Location = bookmark.Resource.Location,
                Description = bookmark.Resource.Metadata.ContainsKey("Description") ? bookmark.Resource.Metadata["Description"] : ""
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            Bookmark existingBookmark = await _context.GetBookmarkAsync(id);
            if (existingBookmark == null)
            {
                return RedirectToPage("./Manage");
            }

            existingBookmark.Title = Bookmark.Title;
            if (existingBookmark.Resource.Metadata.ContainsKey("Description"))
            {
                existingBookmark.Resource.Metadata["Description"] = Bookmark.Description;
            }
            else {
                existingBookmark.Resource.Metadata.Add("Description", Bookmark.Description);
            }
            
            _context.Update(existingBookmark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Manage");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Bookmark bookmark = await _context.GetBookmarkAsync(id);

            if (bookmark == null)
            {
                return RedirectToPage("./Manage");
            }

            _context.Remove(bookmark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Manage");
        }
    }
}
