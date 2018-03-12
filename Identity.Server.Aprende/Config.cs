using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Server.Aprende
{
    public static class Config
    {

        public static IEnumerable<Client> GetClients()
        {

            return new List<Client>
            {
                new Client
                {
                    ClientId = "cliente1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secreto".Sha256())
                    },
                    AllowedScopes = { "resourceApi1" }
                },
                new Client
                {
                    ClientId = "cliente2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secreto2".Sha256())
                    },
                    AllowedScopes = { "resourceApi1" }
                },
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {

            return new List<ApiResource>
            {
                new ApiResource("resourceApi1", "Mi recurso")
            };
        }

    }
}
