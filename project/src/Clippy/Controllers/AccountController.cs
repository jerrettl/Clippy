using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Clippy.Controllers {
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Signin(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties()  { RedirectUri = returnUrl });
        }

        [HttpGet]
        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return Redirect("/errors/403");
        }
    }
}
