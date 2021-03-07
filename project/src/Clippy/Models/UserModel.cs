using Clippy.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Clippy.Models
{
  public class UserModel : PageModel
  {
    private ClippyContext _context;

    public UserModel(ClippyContext context)
    {
      _context = context;
    }

    public string AvatarUrl { get; set; }

    public void OnGet()
    {
          AvatarUrl = "";
          foreach (Claim claim in User.Claims)
          {
              if (claim.Type == "urn:github:avatar") AvatarUrl = claim.Value;
          }
    }
  }
}
