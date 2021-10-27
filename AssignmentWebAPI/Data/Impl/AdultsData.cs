using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AssignmentWebAPI.Model;

namespace AssignmentWebAPI.Data.Impl
{
    public class AdultsData : IAdultsData
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

        public IList<Adult> GetAdults()
        {
            List<Adult> temp = new List<Adult>(adults);
            return temp;
        }

        public void addAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();

        }

        public Adult addAdultTwo(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();
            return adult;

        }

        public void RemoveAdult(int id)
        {
            Adult adultToremove = adults.First(adult => adult.Id == id);
            adults.Remove(adultToremove);
            WriteAdultsToFile();

        }

        public Adult getAdult(int id)
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