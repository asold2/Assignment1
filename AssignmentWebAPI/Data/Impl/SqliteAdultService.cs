using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Schema;
using AssignmentWebAPI.DataAccess;
using AssignmentWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AssignmentWebAPI.Data.Impl
{
    public class SqliteAdultService : IAdultsData
    {
        private FamiliesDbContext ctx;

        public SqliteAdultService(FamiliesDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IList<Adult>> GetAdults()
        {
            return await ctx.Adults.ToListAsync();
        }

        public async Task addAdult(Adult adult)
        {
            EntityEntry<Adult> newAdult = await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
        }

        public async Task<Adult> addAdultTwo(Adult adult)
        {
            EntityEntry<Adult> newAdult = await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
            return newAdult.Entity;
        }

        public async Task RemoveAdult(int id)
        {
            Adult adultToRemove = await ctx.Adults.FirstAsync(adult => adult.Id == id);
            if (adultToRemove != null)
            {
                ctx.Adults.Remove(adultToRemove);
                ctx.SaveChangesAsync();
            }

        }

        public async Task<Adult> getAdult(int id)
        {
            Adult adult = await ctx.Adults.FirstAsync(adult => adult.Id == id);
            return adult;
        }

        // public async Task<Job> getAdultsJob(int id)
        // {
        //     Job job = await ctx.Jobs.FirstAsync(job => job.AdultId == id);
        //     return job;
        // }
    }
}