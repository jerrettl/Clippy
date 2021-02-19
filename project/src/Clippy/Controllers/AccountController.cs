using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Clippy.Controllers {
    [Authorize]
    public class AccountController : Controller {
        private readonly ILogger _logger;
        private int LogoutEventId = 42;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated) {
                returnUrl = null;
            }

            // Clear existing cookie to ensure clean login
            await HttpContext.SignOutAsync();

            return Challenge(new AuthenticationProperties()  { RedirectUri = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            _logger.LogInformation(LogoutEventId, "User logged out.");
            return Redirect("~/");
        }
    }
}
