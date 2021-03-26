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

namespace Clippy.Pages.Admin.Users
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

            List<ImportUserModel> importedUsers;

            try
            {
                importedUsers = JsonSerializer.Deserialize<List<ImportUserModel>>(Json);
            }
            catch
            {
                ModelState.AddModelError("Json", "Error reading JSON.");
                return Page();
            }

            var entities = new List<Entities.User>();

            foreach(var user in importedUsers)
            {
                var entity = new Entities.User();
                entities.Add(entity);

                entity.Username = user.Username;
                entity.Name = user.Name;
                entity.AvatarUrl = user.AvatarUrl;
                entity.Bio = user.Bio;
                entity.CreateDate = DateTime.UtcNow;

                if (!string.IsNullOrWhiteSpace(user.Roles))
                {
                    var chosenRoles = user.Roles.Split(',');

                    foreach(var rolename in chosenRoles) {
                        if (string.IsNullOrWhiteSpace(rolename))
                            continue;

                        var r = await _context.GetRoleByNameAsync(rolename.Trim());
                        if (r == null)
                        {
                            ModelState.AddModelError("Roles", $"{rolename} does not exist.");
                            continue;
                        }

                        entity.Roles.Add(r);
                    }
                }

                _context.AddUser(entity);
            }

            foreach(var user in importedUsers)
            {
                var entity = entities.Find(e => e.Username == user.Username);

                if (!string.IsNullOrWhiteSpace(user.Following))
                {
                    var chosenFollowers = user.Following.Split(',');
                    foreach(var username in chosenFollowers) {
                        if (string.IsNullOrWhiteSpace(username))
                            continue;

                        var account = await _context.GetUserByUsernameAsync(username.Trim());
                        if (account == null)
                        {
                            var importedAccount = entities.FirstOrDefault(e => e.Username == username);
                            if (importedAccount == null) {
                                ModelState.AddModelError("Following", $"{username} does not exist.");
                                continue;
                            }
                            else
                            {
                                entity.Subscriptions.Add(importedAccount);
                            }
                        } else
                        {
                            entity.Subscriptions.Add(account);
                        }
                    }
                }
            }

            if (!ModelState.IsValid)
                return Page();

            try
            {
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{importedUsers.Count} user(s) were successfully imported.";
                return RedirectToPage("./Index");
            }
            catch
            {
                ModelState.AddModelError("Json", "Error saving users to database.");
            }

            return Page();
        }
    }
}
