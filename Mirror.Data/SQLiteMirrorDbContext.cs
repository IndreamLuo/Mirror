using Microsoft.EntityFrameworkCore;
using Mirror.Data.Entities;

namespace Mirror.Data
{
    public class SQLiteMirrorDbContext : MirrorDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Mirror.db");
        }
    }
}