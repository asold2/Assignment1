using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebAPI.Model
{
    public class Adult : Person
    {
        [JsonPropertyName("JobTitle")]
        [AllowNull]
        
        public Job JobTitle { get; set; }
        

    }
}