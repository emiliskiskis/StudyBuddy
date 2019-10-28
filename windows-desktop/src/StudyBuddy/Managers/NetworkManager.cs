using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using StudyBuddy.Models;
using System.Collections.Generic;

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
                BaseAddress = new Uri("http://78.56.77.83:8080")
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

        public async Task<List<ChatHistory>> GetChatHubHistoryAsync(string groupName)
        {
            var response = await _client.GetAsync($"/api/chat/{groupName}");
            return JsonConvert.DeserializeObject<List<ChatHistory>>(await response.Content.ReadAsStringAsync());
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

        public void ReceiveMessage(Action<string, string, string> callback)
        {
            _connection.On<string, string, string>("ReceiveMessage", callback);
        }

        public async void SendMessage(User user, string groupName, string message)
        {
            await _connection.InvokeAsync<string>("SendMessage", user.username, groupName, message);
        }

        public async Task SetUserInformationAsync(string username)
        {
            _userInformation = await GetUserInfoAsync(username);
        }

        public async Task StartHubAsync()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://78.56.77.83:8080" + "/chat")
                .WithAutomaticReconnect()
                .Build();
            await _connection.StartAsync();
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

        public async Task<List<PublicUser>> GetAllUsersAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/users");
                return JsonConvert.DeserializeObject<List<PublicUser>>(await response.Content.ReadAsStringAsync());
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

        public async Task<String> GetGroupNameAsync(string currentUsername, string targetUsername)
        {
            var jsonContent = new { username = currentUsername, connectTo = targetUsername };
            try
            {
                string json = JsonConvert.SerializeObject(jsonContent);
                using var request = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("api/chat", request);
                ChatGroup group = JsonConvert.DeserializeObject<ChatGroup>(await response.Content.ReadAsStringAsync());
                return group.groupName;
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
