using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Assignment1.Data.Impl
{
    public class AdultsData:IAdultsData
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultsData()
        {
            if (!File.Exists(adultFile))
            {
                
                WriteAdultsToFile();
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
                
            }
        }

        public async Task<IList<Adult>>  GetAdultsAsync()
        {
            List<Adult> temp = new List<Adult>(adults);
            return temp;
        }

        public async Task addAdultAsync(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();

        }

        public async Task RemoveAdultAsync(int id)
        {
            Adult adultToremove = adults.First(adult => adult.Id == id);
            adults.Remove(adultToremove);
            WriteAdultsToFile();

        }

        public async Task<Adult> getAdultAsync(int id)
        {
            return adults.FirstOrDefault(adult => adult.Id == id);
        }

        private void WriteAdultsToFile()
        {
            string adultsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, adultsAsJson);
        }
        
    }
}