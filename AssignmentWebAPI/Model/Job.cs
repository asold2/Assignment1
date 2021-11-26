using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebAPI.Model
{
  
    
    public class Job 
    {
        [JsonPropertyName("AdultId"), ForeignKey("AdultId")]
        public int AdultId { get; set; }

        [JsonPropertyName("JobTitle")]
        public string JobTitle { get; set; }
        [JsonPropertyName("Salary")]
        public int Salary { get; set; }
    }
}