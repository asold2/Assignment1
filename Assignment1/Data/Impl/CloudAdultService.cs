using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Assignment1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Data.Impl
{
    public class CloudAdultService : IAdultsData
    {
        private string uri = "https://localhost:5002";
        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            using HttpClient client = new HttpClient();
            Task<string> stringAsync = client.GetStringAsync(uri + "/Adult");
            string message = await stringAsync;
            IList<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }

        public async Task addAdultAsync(Adult adult)
        {
            using HttpClient client = new HttpClient();
            string adultAsJson = JsonSerializer.Serialize(adult, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            HttpContent content1 = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            Console.WriteLine(adultAsJson + ">>>>>>>>>>");
            await client.PostAsync( uri + "/Adult", content1 );
            Console.WriteLine("Here");
        }

        public async  Task RemoveAdultAsync(int id)
        {
            using HttpClient client = new HttpClient();
            await client.DeleteAsync(uri + $"/Adult/{id}");

        }

        public Task<Adult> getAdultAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}