using AssignmentWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssignmentWebAPI.DataAccess
{
    public class FamiliesDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<LoginUser> Users { get; set; }
        public DbSet<Adult> Adults { get; set; }
        // public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Families.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adult>().OwnsOne(j => j.JobTitle);
            // modelBuilder.Entity<Job>().HasNoKey();
        }
    }
}