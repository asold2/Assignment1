using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentWebAPI.DataAccess;
using AssignmentWebAPI.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AssignmentWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (FamiliesDbContext ctx = new FamiliesDbContext())
            {
                if (!ctx.Users.Any())
                {
                    ctx.Users.AddAsync(new LoginUser("Andrei", "Admin", "pass"));
                    ctx.Users.AddAsync(new LoginUser("Costel", "Admin", "pass"));
                }
            }


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}