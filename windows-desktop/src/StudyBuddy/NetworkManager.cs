using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace StudyBuddy
{
    public class NetworkManager
    {
        private readonly static HttpClient client = new HttpClient();
        static HubConnection connection;
        static User userInformation;

        public static void Setup()
        {
            client.BaseAddress = new Uri("http://www.buddiesofstudy.tk:80/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                
                var response = await client.PostAsync("api/users", new StringContent(json, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            catch(JsonSerializationException)
            {
                return null;
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
                var response = await client.PostAsync("api/login", new StringContent(json, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            catch (JsonSerializationException)
            {
                return null;
            }
        }

        public static async Task<User> GetUserInfoAsync(string username)
        {
            var response = await client.GetAsync($"api/users/{username}");
            try
            {
                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }
            catch(JsonSerializationException)
            {
                return null;
            }
        }

        public static void StartHub()
        {
            connection = new HubConnectionBuilder().
                WithUrl("http://78.56.77.83:8080/chat")
                .WithAutomaticReconnect()
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }
        
        public static void ConnectToGroup(ChatGroupSession session)
        {
            try
            {
                connection.InvokeAsync("Connect", session.user.username, session.groupId);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
        
        public static void SendMessage(User user, string groupName, string message) 
        {
            try
            {
                connection.InvokeAsync<string>("SendMessage", user.username, groupName, message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
        
        public static void SetUserInformation(string username)
        {
            userInformation = GetUserInfoAsync(username).Result;
            Console.WriteLine("info set?");
        }

        public static User GetUserInformation()
        {
            return userInformation;
        }
    }
}
