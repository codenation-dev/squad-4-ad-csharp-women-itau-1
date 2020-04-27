using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4.Test;
using System.Security.Claims;
using IdentityServer4;

namespace ProjetoPraticoCodenation.ConfigStartup
{
    public static class IdentityConfig
    {
        public static IEnumerable<IdentityResource> GetRecursosIdentity()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }


        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>() {
                new ApiResource(
                    name: "codenation_projetoFinal",
                    displayName: "Codenation Projeto",
                    claimTypes: new [] {
                        ClaimTypes.Role,
                        ClaimTypes.Email
                    }
                )
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>() {
                new Client
                {
                    ClientName = "Client Projeto Final",
                    ClientId = "codenation_projetoFinal.api_client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret("codenation_projetoFinal.api_secret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "codenation_projetoFinal"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "ls.sz",
                    Password = "456",
                    Claims = new [] {
                        new Claim(ClaimTypes.Role, "user"),
                        new Claim(ClaimTypes.Email, "elis@email.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "rql.prts",
                    Password = "789",
                    Claims = new [] {
                        new Claim(ClaimTypes.Role, "user"),
                        new Claim(ClaimTypes.Email, "raquel@email.com")
                    }
                }
            };
        }
    }

}

