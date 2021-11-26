﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AssignmentWebAPI.Model
{
    public class Person
    {
        [JsonPropertyName("Id"), Key]
        public int Id { get; set; }
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("HairColor")]
        public string HairColor { get; set; }
        [JsonPropertyName("EyeColor")]
        public string EyeColor { get; set; }
        [JsonPropertyName("Age")]
        public int Age { get; set; }
        [JsonPropertyName("Weight")]
        public float Weight { get; set; }
        [JsonPropertyName("Height")]
        public int Height { get; set; }
        [JsonPropertyName("Sex")]
        public string Sex { get; set; }
        
    }
}