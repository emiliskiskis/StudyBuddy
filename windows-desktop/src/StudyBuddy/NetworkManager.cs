using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public class NetworkManager
    {
        private readonly static HttpClient client = new HttpClient();

        public static void Setup()
        {
            client.BaseAddress = new Uri("http://www.buddiesofstudy.tk/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                Console.WriteLine(json);

                var response = await client.PostAsync("api/users", new StringContent(json, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            catch (JsonSerializationException)
            {
                return false;
            }
        }

        public static async Task<string> GetSaltAsync(string username)
        {
            var response = await client.GetAsync($"api/users/{username}/salt");
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<bool> CheckHash(string username, string password)
        {
            var credentials = new { username, password };
            try
            {
                string json = JsonConvert.SerializeObject(credentials);
                var response = await client.PostAsync("api/login", new StringContent(json, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
            }
            catch (JsonSerializationException)
            {
                return false;
            }
        }

        public static async Task<User> GetUserInfoAsync(string username)
        {
            var response = await client.GetAsync($"api/users/{username}");
            try
            {
                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }
            catch (JsonSerializationException)
            {
                return null;
            }
        }
    }
}
