using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages {
    public class Index : PageModel {
        [ViewData]
        public string Title { get; } = "Home";

        public void OnGet() {

        }
    }
}
