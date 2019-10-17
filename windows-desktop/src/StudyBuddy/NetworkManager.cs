﻿using Newtonsoft.Json;
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
            //Console.WriteLine(json);

            HttpResponseMessage response = await client.PostAsync(
                "api/user",
                new StringContent(json, Encoding.UTF8, "application/json"));

            //Console.WriteLine(new StringContent(json, Encoding.UTF8, "application/json").Headers);

            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public static async Task<string> GetSaltAsync(string username)
        {
            HttpResponseMessage response = await client.GetAsync(
                "api/user/"+username+"/salt");

            //Console.WriteLine(new StringContent(json, Encoding.UTF8, "application/json").Headers);

            try
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return response.StatusCode.ToString();
            }

        }

        public static async Task<bool> CheckHashAsync(string username, string password)
        {
            var credentials = new { username, password };
            string json = JsonConvert.SerializeObject(credentials);

            HttpResponseMessage response = await client.PostAsync(
                "api/login",
                new StringContent(json, Encoding.UTF8, "application/json"));

            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Setup()
        {
            client.BaseAddress = new Uri("http://buddiesofstudy.tk");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

    }
}
