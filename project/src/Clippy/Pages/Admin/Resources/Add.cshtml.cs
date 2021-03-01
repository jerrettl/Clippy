using System;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Resources
{
    public class AddModel : PageModel
    {
        private ClippyContext _context;

        public AddModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public AddResourceModel Resource { get; set; }

        public void OnGet() {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingResource = await _context.GetResourceByLocationAsync(Resource.Location);
            if (existingResource != null) {
                ModelState.AddModelError("Location", $"Resource already exists: Id = {existingResource.Id}.");
            }

            if (!ModelState.IsValid)
                return Page();

            // TODO: Validate URL Exists

            var resource = new Resource
            {
                Location = Resource.Location,
                Metadata = Resource.FetchMetadata(),
                CreateDate = DateTime.UtcNow
            };

            _context.AddResource(resource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
