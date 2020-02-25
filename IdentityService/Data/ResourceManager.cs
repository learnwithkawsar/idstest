using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Data
{
    internal static class ResourceManager
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource {
                    Name = "app.api.whatever",
                    DisplayName = "Whatever Apis",
                    ApiSecrets = { new Secret("a75a559d-1dab-4c65-9bc0-f8e590cb388d".Sha256()) },
                    Scopes = new List<Scope> {
                        new Scope("app.api.whatever.read"),
                        new Scope("app.api.whatever.write"),
                        new Scope("app.api.whatever.full")
                    }
                },
                new ApiResource("app.api.weather","Weather Apis")
            };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
                // some standard scopes from the OIDC spec
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),

                // custom identity resource with some consolidated claims
                new IdentityResource("custom.profile", new[] { JwtClaimTypes.Name, JwtClaimTypes.Email, "location" })
        };

        public static IEnumerable<Scope> Get => new List<Scope>
    {
        
            new Scope
            {
                Name = "api1",
                DisplayName = "API 1",
                Description = "API 1 features and data"

            }
       
    };
    }
}
