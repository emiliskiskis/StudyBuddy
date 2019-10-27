using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Threading;

namespace StudyBuddy
{
    public class NetworkManager
    {
        static HttpClient client = new HttpClient();
        static HubConnection connection;
        static User userInformation;

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
                SetUserInformation(user.username);
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
                    new StringContent(json, Encoding.UTF8, "application/json")
                ).GetAwaiter().GetResult();


                response.EnsureSuccessStatusCode();
                return true;
            }
            catch(HttpRequestException exc)
            {
                Console.WriteLine(exc);
                return false;
            }
        }

        public static async Task<User> GetUserInfoAsync(string username)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(
                    "api/users/" + username).GetAwaiter().GetResult();

                response.EnsureSuccessStatusCode();
                var UserHold = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                return UserHold;
            }
            catch(HttpRequestException exc)
            {
                Console.WriteLine(exc);
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
        public static void Setup()
        {
            client.BaseAddress = new Uri("http://www.buddiesofstudy.tk:80/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
