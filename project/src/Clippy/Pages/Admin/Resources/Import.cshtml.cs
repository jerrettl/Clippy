using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Clippy.Pages.Admin.Resources
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

            List<ImportResourceModel> importedResources;

            try
            {
                importedResources = JsonSerializer.Deserialize<List<ImportResourceModel>>(Json);
            }
            catch
            {
                ModelState.AddModelError("Json", "Error reading JSON.");
                return Page();
            }

            foreach(var resource in importedResources)
            {
                var entity = new Entities.Resource();
                entity.Location = resource.Location;
                entity.Metadata = resource.Metadata;
                entity.CreateDate = DateTime.UtcNow;

                _context.AddResource(entity);
            }

            try
            {
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{importedResources.Count} resource(s) were successfully imported.";
                return RedirectToPage("./Index");
            }
            catch
            {
                ModelState.AddModelError("Json", "Error saving resources to database.");
            }

            return Page();
        }
    }
}
