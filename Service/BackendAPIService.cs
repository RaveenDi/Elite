using Elite.Models;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Elite.Service
{
    public class BackendAPIService
    {
        private readonly HttpClient httpClient = new HttpClient();

        public BackendAPIService()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5133/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<User> GetUserAsync(string username)
        {
            User user = null;
            HttpResponseMessage response = await httpClient.GetAsync("api/user/" + username);
            if (response.IsSuccessStatusCode)
            {
                string userString = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(userString);
            }
            return user;
        }

        public async Task<Boolean> AddUser(User user)
        {
            HttpResponseMessage response = await httpClient.PostAsync("api/user", 
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<User> Updateuser(string id, User user)
        {
            HttpResponseMessage response = await httpClient.PutAsync($"api/user/{id}", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            string userString = await response.Content.ReadAsStringAsync();
            user = JsonConvert.DeserializeObject<User>(userString);
            return user;
        }

        public async Task<HttpStatusCode> DeleteUser(string id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"api/user/{id}");
            return response.StatusCode;
        }
    }
}
