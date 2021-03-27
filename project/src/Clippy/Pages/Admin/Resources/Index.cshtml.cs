using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Resources
{
    public class IndexModel : PageModel
    {
        private ClippyContext _context;

        public IndexModel(ClippyContext context) {
            _context = context;
        }

         public IList<Resource> Resources { get; set; }

        public async Task OnGetAsync() {
            Resources = await _context.GetResourcesAsync();
        }

        public async Task<IActionResult> OnPostExportAsync() {
            var resources = await _context.GetResourcesAsync();

            var exportedResources = new List<ExportResourceModel>();
            foreach(var resource in resources)
            {
                exportedResources.Add(new ExportResourceModel{
                    Id = resource.Id,
                    Location = resource.Location,
                    Metadata = resource.Metadata
                });
            }

            return new JsonResult(exportedResources, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }
    }
}
