using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Data.Impl
{
    public class CloudUserService: IUserService
    {
        public async Task<LoginUser> ValidateUserAsync(string username, string password)
        {
            HttpClient client = new HttpClient();
            Task<string> stringAsync =
                client.GetStringAsync($"https://localhost:5002/User?username={username}&password={password}");
            string userAsJson = await stringAsync;
            var finalUser = JsonSerializer.Deserialize<LoginUser>(userAsJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            
            return finalUser;
            
        }

        }
    }
