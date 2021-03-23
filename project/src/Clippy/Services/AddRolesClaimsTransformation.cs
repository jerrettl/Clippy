using Clippy.Data;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clippy.Services
{
    public class AddRolesClaimsTransformation : IClaimsTransformation
    {
        private ClippyContext _context;

        public AddRolesClaimsTransformation(ClippyContext context)
        {
            _context = context;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var roleClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim != null)
                return principal;

            var username = principal.Claims.FirstOrDefault(c => c.Type == "urn:github:login");
            if (username == null)
                return principal;

            var user = await _context.GetUserByUsernameAsync(username.Value);
            if (user == null || !user.Roles.Any())
                return principal;

            // Add role claims
            var clone = principal.Clone();
            var newIdentity = (ClaimsIdentity)clone.Identity;

            foreach(var role in user.Roles)
            {
                newIdentity.AddClaim(new Claim(newIdentity.RoleClaimType, role.Name));
            }

            return clone;
        }
    }
}
