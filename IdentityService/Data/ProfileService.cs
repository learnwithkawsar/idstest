using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityService.Data
{
    public class ProfileService : IProfileService
    {
        MyUserManager _myUserManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _myUserManager = new MyUserManager();
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub")?.Value;
            if (sub != null)
            {
                var user = await _userManager.FindByNameAsync(sub);
                var cp = await getClaims(user);

                var claims = cp.Claims.ToList();
                if (context.RequestedClaimTypes != null && context.RequestedClaimTypes.Any())
                {
                    claims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToArray().AsEnumerable().ToList();
                }

                context.IssuedClaims = claims;
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
             context.IsActive=true;
        }

        private async Task<ClaimsPrincipal> getClaims(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var id = new ClaimsIdentity();
            id.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, user.UserName));
            id.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
 
            var Roles = await _userManager.GetRolesAsync(user);
            if (Roles.Count > 0)
            {
                foreach (var item in Roles)
                {
                    id.AddClaim(new Claim(JwtClaimTypes.Role, item));
                }
                
            }

            return new ClaimsPrincipal(id);
        }

    }
}
