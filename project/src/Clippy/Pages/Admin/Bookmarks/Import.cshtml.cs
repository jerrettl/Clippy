using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Helpers;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Clippy.Pages.Admin.Bookmarks
{
    public class ImportModel : PageModel
    {
        private ClippyContext _context;
        private ILogger _logger;

        public ImportModel(ClippyContext context, ILogger<AddModel> logger) {
            _context = context;
            _logger = logger;
        }

        [BindProperty, Required]
        public string Json { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            List<ImportBookmarkModel> importedBookmarks;

            try
            {
                importedBookmarks = JsonSerializer.Deserialize<List<ImportBookmarkModel>>(Json);
            }
            catch
            {
                ModelState.AddModelError("Json", "Error reading JSON.");
                return Page();
            }

            foreach(var bookmark in importedBookmarks)
            {
                var entity = new Entities.Bookmark();

                var resource = await _context.GetResourceByLocationAsync(bookmark.Location);
                if (resource == null)
                {
                    ModelState.AddModelError("Location", $"Resource does not exist for {bookmark.Location}. Resource must be added first.");
                    return Page();
                }
                entity.ResourceId = resource.Id;

                var user = await _context.GetUserByUsernameAsync(bookmark.Username);
                if (user == null)
                {
                    ModelState.AddModelError("Username", $"User does not exist for {bookmark.Username}. User must be added first.");
                    return Page();
                }
                entity.UserId = user.Id;

                entity.Title = bookmark.Title ?? "";
                entity.Description = bookmark.Description ?? "";
                entity.IsPublic = bookmark.Public;
                entity.Favorited = bookmark.Favorite;
                entity.Tags = BookmarkTagHelper.StringToList(bookmark.Tags);
                entity.CreateDate = DateTime.UtcNow;

                _context.AddBookmark(entity);
            }

            try
            {
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{importedBookmarks.Count} bookmark(s) were successfully imported.";
                return RedirectToPage("./Index");
            }
            catch
            {
                ModelState.AddModelError("Json", "Error saving bookmarks to database.");
            }

            return Page();
        }
    }
}
