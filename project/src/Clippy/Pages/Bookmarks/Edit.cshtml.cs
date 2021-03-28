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

        public User ThisUser { get; set; }

        public string ReturnPage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string githubId = "";
            foreach (Claim claim in User.Claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier) githubId = claim.Value;
            }

            ThisUser = await _context.GetUserByGithubId(githubId);
            Bookmark bookmark = await _context.GetBookmarkAsync(id);
            if (ThisUser == null || bookmark == null || !ThisUser.Id.Equals(bookmark.UserId))
            {
                return RedirectToPage("./Manage");
            }

            Bookmark = new EditBookmarkModel
            {
                Id = bookmark.Id,
                Title = bookmark.Title ?? "",
                Location = bookmark.Resource.Location,
                Description = bookmark.Description ?? "",
                Tags = BookmarkTagHelper.ListToString(bookmark.Tags),
                IsPublic = bookmark.IsPublic,
                Favorited = bookmark.Favorited
            };

            ReturnPage = Request.Query.ContainsKey("return") ? Request.Query["return"] : "./Manage";

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

            existingBookmark.Title = !string.IsNullOrWhiteSpace(Bookmark.Title) ? Bookmark.Title : null;
            existingBookmark.Description = !string.IsNullOrWhiteSpace(Bookmark.Description) ? Bookmark.Description : null;
            existingBookmark.Tags = BookmarkTagHelper.StringToList(Bookmark.Tags);
            existingBookmark.IsPublic = Bookmark.IsPublic;
            existingBookmark.Favorited = Bookmark.Favorited;
            
            _context.Update(existingBookmark);
            await _context.SaveChangesAsync();

            string returnPage = Request.Query.ContainsKey("return") ? Request.Query["return"] : "./Manage";
            return RedirectToPage(returnPage);
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

            string returnPage = Request.Query.ContainsKey("return") ? Request.Query["return"] : "./Manage";
            return RedirectToPage(returnPage);
        }
    }
}
