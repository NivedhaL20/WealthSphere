using Microsoft.EntityFrameworkCore;
using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Repository
{
    public class WealthSphereDbContext : DbContext
    {
        public WealthSphereDbContext(DbContextOptions<WealthSphereDbContext> options)
        : base(options)
        { }

        public DbSet<Registration> Registration { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Investment> Investment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Income>()
                .HasKey(i => i.Id);
        }

        //EF Migration commands
        //Open Tools -> Nuget Package Manager -> Package Manager Console
        //Add-Migration InitialCommit
        //Update-Database
        //Remove-Migration
        //Get-Migrations
    }
}
