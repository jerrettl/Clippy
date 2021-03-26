using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

        public IList<Role> Roles { get; set; }

        public async Task OnGetAsync() {
            Roles = await _context.GetRolesAsync();
        }

        public async Task<IActionResult> OnPostExportAsync() {
            var roles = await _context.GetRolesAsync();

            var exportedRoles = new List<ExportRoleModel>();
            foreach(var role in roles)
            {
                exportedRoles.Add(new ExportRoleModel{
                    Id = role.Id,
                    Name = role.Name
                });
            }

            return new JsonResult(exportedRoles, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }
    }
}
