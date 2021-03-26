using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Clippy.Pages.Admin.Roles
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

            List<ImportRoleModel> importedRoles;

            try
            {
                importedRoles = JsonSerializer.Deserialize<List<ImportRoleModel>>(Json);
            }
            catch
            {
                ModelState.AddModelError("Json", "Error reading JSON.");
                return Page();
            }

            foreach(var role in importedRoles)
            {
                var entity = new Entities.Role();
                entity.Name = role.Name;

                _context.AddRole(entity);
            }

            try
            {
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{importedRoles.Count} role(s) were successfully imported.";
                return RedirectToPage("./Index");
            }
            catch
            {
                ModelState.AddModelError("Json", "Error saving roles to database.");
            }

            return Page();
        }
    }
}
