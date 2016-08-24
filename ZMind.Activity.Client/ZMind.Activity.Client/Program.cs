using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityModel.Extensions;

namespace ZMind.Activity.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = GetUserToken();
            CallApi(response);
            Console.ReadKey();
        }
        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            HttpContent content = new StringContent("{\"PosStoreCode\": \"sample string 1\",\"PosOperater\": \"sample string 2\",\"PosSn\": \"sample string 3\",\"Request\": {\"StoreCode\": \"sample string 1\"}}");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync("http://localhost:50073/api/QCTCCustom/Unit/UnitDelete", content).Result;
            Console.WriteLine();
        }
        static TokenResponse GetUserToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "TestClient",
                "secret");

            return client.RequestResourceOwnerPasswordAsync("terry", "kkndkknd", "ActivityApi").Result;
        }
    }
}
