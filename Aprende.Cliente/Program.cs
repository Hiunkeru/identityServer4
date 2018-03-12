using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aprende.Cliente
{
    public class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        //public static void Main(string[] args)
        //{
        //    MainAsync().GetAwaiter().GetResult();
        //}

        private static async Task MainAsync()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            if (disco.IsError)
            {
                throw new Exception("error");
            }

            var TokenCliente = new TokenClient(disco.TokenEndpoint, "cliente1", "secreto1");
            var TokenResponse = await TokenCliente.RequestClientCredentialsAsync("resourceApi1");

            if (TokenResponse.IsError)
            {
                throw new Exception("error");
            }

            var TokenJson = TokenResponse.Json;


            //A partir de aqui hacemos la llamada a nuestra API

            var client = new HttpClient();
            client.SetBearerToken(TokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/api/aprende");

            if (!response.IsSuccessStatusCode) {
                throw new Exception("error");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();

            }


        }
    }
}
