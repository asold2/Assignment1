using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentWebAPI.Model;

namespace AssignmentWebAPI.Data.Impl
{
    public class AlreadyExistentUsers:IUserService
    {

        private ICollection<LoginUser> users;
        public AlreadyExistentUsers()
        {
            users = new List<LoginUser>();

            users.Add(new LoginUser
                {
                    UserName = "Andrei",
                    Role = "Admin",
                    Password = "123456"
                    
                });
                users.Add(new LoginUser
                {
                    UserName = "Ion",
                    Role = "Admin",
                    Password = "654321"
                });
        }

        public async Task<LoginUser> ValidateUser(string username, string password)
        {
            LoginUser first = users.FirstOrDefault(user => user.UserName.Equals(username) && user.Password.Equals(password));
            if (first != null)
            {
                return first;
            }

            throw new Exception("User not found");
        }
    }
}