using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Model;

namespace Assignment1.Data.Impl
{
    public class AlreadyExistentUsers:IUserService
    {
        private List<LoginUser> loginUsers;

        public AlreadyExistentUsers()
        {
            loginUsers = new[]
            {
                new LoginUser
                {
                    UserName = "Andrei",
                    Password = "123456",
                    Role = "Admin"
                },
                new LoginUser
                {
                    UserName = "serafim",
                    Password = "theend",
                    Role = "Admin"
                }
            }.ToList();
        }

        public async Task<LoginUser>  ValidateUserAsync(string username, string password)
        {
            LoginUser first = loginUsers.FirstOrDefault(user => user.UserName.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Wrong password");
            }

            return first;
        }
    }
}