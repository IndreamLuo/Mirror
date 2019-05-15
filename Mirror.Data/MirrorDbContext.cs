using Microsoft.EntityFrameworkCore;
using Mirror.Data.Entities;

namespace Mirror.Data
{
    public class MirrorDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Vendor> Vendor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasIndex(service => service.Key)
                .IsUnique();
        }
    }
}