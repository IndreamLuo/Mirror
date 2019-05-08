using Microsoft.EntityFrameworkCore;
using Mirror.Data.Entities;

namespace Mirror.Data
{
    public class MirrorContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
    }
}