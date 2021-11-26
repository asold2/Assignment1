using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AssignmentWebAPI.Model
{
    public class LoginUser
    {



        [JsonPropertyName("UserName"), Key]
        public string UserName { get; set; }
        [JsonPropertyName("Role")]
        public string Role { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        
        
        public LoginUser(string UserName, string Role, string Password)
        {
            this.UserName = UserName;
            this.Role = Role;
            this.Password = Password;
        }
        
        
    }
}