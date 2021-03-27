using System;
using System.Threading.Tasks;
using Clippy.Data;
using Clippy.Entities;
using Clippy.Helpers;
using Clippy.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clippy.Pages.Admin.Resources
{
    public class EditModel : PageModel
    {
        private ClippyContext _context;

        public EditModel(ClippyContext context) {
            _context = context;
        }

        [BindProperty]
        public EditResourceModel Resource { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var resource = await _context.GetResourceAsync(id);
            if (resource == null)
            {
                TempData["Message"] = $"Resource not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            Resource = new EditResourceModel
            {
                Title = resource.Metadata.ContainsKey("Title") ? resource.Metadata["Title"] : "",
                Location = resource.Location,
                MediaType = resource.Metadata.ContainsKey("MediaType") ? resource.Metadata["MediaType"] : "",
                Image = resource.Metadata.ContainsKey("ImageURL") ? resource.Metadata["ImageURL"] : "",
                Description = resource.Metadata.ContainsKey("Description") ? resource.Metadata["Description"] : ""
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            var existingResource = await _context.GetResourceAsync(id);
            if (existingResource == null)
            {
                TempData["Message"] = $"Resource not found. Id = {id}.";
                return RedirectToPage("./Index");
            }

            if (Resource.Location != existingResource.Location) {
                var existingLocation = await _context.GetResourceByLocationAsync(Resource.Location);
                if (existingLocation != null)
                    ModelState.AddModelError("Location", $"Resource already exists: Id = {existingLocation.Id}.");
            }

            if (!ModelState.IsValid)
                return Page();

            existingResource.Location = Resource.Location;
            existingResource.Metadata.MergeMetadata(Resource.FetchMetadata());

            _context.Update(existingResource);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"The resource, {Resource.Title}, was successfully updated.";

            return RedirectToPage("./Index");
        }
    }
}
