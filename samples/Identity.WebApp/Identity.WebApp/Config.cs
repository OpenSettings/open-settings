using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace Identity.WebApp;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("api1")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // machine to machine client ( from quickstart 1 ) OAuth Clients
            new Client 
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // No interactive user, use the clientId/secret for auth
                ClientSecrets = { new Secret("secret".Sha256())}, // Secret for authentication
                AllowedScopes = { "api1" } // Scopes that client has access to
            },
            // Interactive Asp.Net Core Web App
            new Client
            {
                ClientId = "web",
                ClientSecrets = { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "http://localhost:5002/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc"},
                AllowOfflineAccess = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 7200
            }
        };
}