using Clippy.Data;
using Clippy.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clippy.Pages.Admin.Profile
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

         public User UserEntity { get; set; }

        public async Task OnGetAsync() {
            var username = User.Claims.First(c => c.Type == "urn:github:login").Value;
            UserEntity = await _context.GetUserByUsernameAsync(username);
        }
    }
}
