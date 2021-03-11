using System.Collections.Generic;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
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
    }
}
