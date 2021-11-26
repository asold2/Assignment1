using System;
using System.Threading.Tasks;
using AssignmentWebAPI.DataAccess;
using AssignmentWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebAPI.Data.Impl
{
    public class SqliteExistentUserService : IUserService
    {
        private FamiliesDbContext ctx;
        
        public SqliteExistentUserService(FamiliesDbContext ctx)
        {
            this.ctx = ctx;
            ctx.Users.AddAsync(new LoginUser("Andrei", "Admin", "pass"));
            ctx.Users.AddAsync(new LoginUser("Costel", "Admin", "pass"));

            
        }


        public async Task<LoginUser> ValidateUser(string username, string password)
        {
            LoginUser user = await ctx.Users.FirstAsync(user => user.UserName.Equals(username) && user.Password.Equals(password));
            if (user != null)
            {
                return user;
            }
            throw new Exception("User not found");
        }
    }
}