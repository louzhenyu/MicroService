using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            Console.WriteLine(client.GetStringAsync("http://localhost:3880/api/activity?activityId=1").Result);
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
