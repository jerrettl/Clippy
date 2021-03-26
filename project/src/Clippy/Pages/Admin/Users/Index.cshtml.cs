using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

         public IList<User> Users { get; set; }

        public async Task OnGetAsync() {
            Users = await _context.GetUsersAsync();
        }

        public async Task<IActionResult> OnPostExportAsync() {
            var users = await _context.GetUsersExportAsync();

            var exportedUsers = new List<ExportUserModel>();
            foreach(var user in users)
            {
                var rb = new StringBuilder();
                foreach(var role in user.Roles)
                {
                    rb.Append($"{role.Name},");
                }

                var sb = new StringBuilder();
                foreach(var subscription in user.Subscriptions)
                {
                    sb.Append($"{subscription.Username},");
                }

                exportedUsers.Add(new ExportUserModel{
                    Id = user.Id,
                    Username = user.Username,
                    Name = user.Name,
                    AvatarUrl = user.AvatarUrl,
                    Bio = user.Bio,
                    Roles = rb.ToString().TrimEnd(','),
                    Following = sb.ToString().TrimEnd(',')
                });
            }

            return new JsonResult(exportedUsers, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }
    }
}
