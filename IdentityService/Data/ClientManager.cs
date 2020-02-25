using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityService.Data
{
    internal static class ClientManager
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                    new Client
                    {
                         ClientName = "Client Application1",
                         ClientId = "t8agr5xKt4$3",
                         AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                         ClientSecrets = { new Secret("eb300de4-add9-42f4-a3ac-abd3c60f1919".Sha256()) },
                         AllowedScopes = new List<string> { "app.api.whatever.read", "app.api.whatever.write" }
                    },
                    new Client
                    {
                         ClientName = "Client Application2",
                         ClientId = "3X=nNv?Sgu$S",
                         AllowedGrantTypes = GrantTypes.ClientCredentials,
                         ClientSecrets = { new Secret("1554db43-3015-47a8-a748-55bd76b6af48".Sha256()) },
                         AllowedScopes = { "app.api.weather" }
                    },
                    new Client
                {
                    ClientId = "spaclient",
                    ClientName = "SPA Client",
                    ClientUri = "https://localhost:5003",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =
                    {
                        "https://localhost:5003/index.html",
                        "https://localhost:5003/callback.html"
                    },

                    PostLogoutRedirectUris = { "https://localhost:5003/index.html" },
                    AllowedCorsOrigins = { "https://localhost:5003" },

                    AllowedScopes = { "openid", "profile", "identity.api" ,"test.api" }
                    }
            };
    }
}
