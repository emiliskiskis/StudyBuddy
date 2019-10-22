using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public class NetworkManager
    {
        static HttpClient client = new HttpClient();

        public static async Task<bool> CreateUserAsync(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            Console.WriteLine(json);

            try
            {
                HttpResponseMessage response = await client.PostAsync(
                "api/users/",
                new StringContent(json, Encoding.UTF8, "application/json"));

            
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public static async Task<string> GetSaltAsync(string username)
        {
            HttpResponseMessage response = client.GetAsync(
                "api/users/" + username + "/salt").GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public static bool CheckHash(string username, string password)
        {
            try
            {
                var credentials = new { username, password };
                string json = JsonConvert.SerializeObject(credentials);
                HttpResponseMessage response = client.PostAsync(
                    "api/login",
                    new StringContent(json, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();


                response.EnsureSuccessStatusCode();
                return true;
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
                return false;
            }
        }

        public static async Task<User> GetUserInfoAsync(string username)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    "api/users/" + username);

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
        }

        public static void Setup()
        {
            client.BaseAddress = new Uri("http://www.buddiesofstudy.tk:80/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
