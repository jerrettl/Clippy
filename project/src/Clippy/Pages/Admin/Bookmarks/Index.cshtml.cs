using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Helpers;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Bookmarks
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

         public IList<Bookmark> Bookmarks { get; set; }

        public async Task OnGetAsync() {
            Bookmarks = await _context.GetBookmarksAsync();
        }

        public async Task<IActionResult> OnPostExportAsync() {
            var bookmarks = await _context.GetBookmarksAsync();

            var exportedBookmarks = new List<ExportBookmarkModel>();
            foreach(var bookmark in bookmarks)
            {
                exportedBookmarks.Add(new ExportBookmarkModel{
                    Id = bookmark.Id,
                    Location = bookmark.Resource.Location,
                    Title = bookmark.Title ?? "",
                    Description = bookmark.Description ?? "",
                    Public = bookmark.IsPublic,
                    Tags = BookmarkTagHelper.ListToString(bookmark.Tags),
                    Username = bookmark.User.Username
                });
            }

            return new JsonResult(exportedBookmarks, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }
    }
}
