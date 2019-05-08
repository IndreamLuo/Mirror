using Microsoft.EntityFrameworkCore;
using Mirror.Data.Entities;

namespace Mirror.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}