using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using StudyBuddy.Models;

namespace StudyBuddy.Managers
{
    public class NetworkManager : IDisposable
    {
        private readonly HttpClient _client;
        private HubConnection _connection;
        private User _userInformation;

        public NetworkManager()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://www.buddiesofstudy.tk/")
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        ~NetworkManager()
        {
            Dispose(false);
        }

        public async Task<bool> CheckHashAsync(string username, string password)
        {
            var credentials = new { username, password };
            try
            {
                string json = JsonConvert.SerializeObject(credentials);
                using var request = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("api/login", request);
                return response.IsSuccessStatusCode;
            }
            catch (JsonSerializationException)
            {
                return false;
            }
        }

        public async void ConnectToGroup(ChatGroupSession session)
        {
            await _connection.InvokeAsync("Connect", session.user.username, session.groupId);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                using var request = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("api/users", request);
                return response.IsSuccessStatusCode;
            }
            catch (JsonSerializationException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<string> GetSaltAsync(string username)
        {
            var response = await _client.GetAsync($"api/users/{username}/salt");
            return await response.Content.ReadAsStringAsync();
        }

        public User GetUserInfo()
        {
            return _userInformation;
        }

        public async void SendMessage(User user, string groupName, string message)
        {
            await _connection.InvokeAsync<string>("SendMessage", user.username, groupName, message);
        }

        public async Task SetUserInformationAsync(string username)
        {
            _userInformation = await GetUserInfoAsync(username);
        }

        public void StartHub()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(_client.BaseAddress + "chat")
                .WithAutomaticReconnect()
                .Build();

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
        }

        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                _client.Dispose();
            }
        }

        private async Task<User> GetUserInfoAsync(string username)
        {
            try
            {
                var response = await _client.GetAsync($"api/users/{username}");
                return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            }
            catch (JsonSerializationException)
            {
                return null;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
