using System.Linq;
using Mirror.Application.Service;
using Mirror.Data;

namespace Mirror.Application.Install
{
    public class InstallApplication : IInstallApplication
    {
        readonly MirrorDbContext DbContext;

        public InstallApplication(MirrorDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void EnsureInstalled()
        {
            EnsureDbInitialized();
        }

        protected void EnsureDbInitialized()
        {
            if (DbContext is SQLiteMirrorDbContext)
            {
                DbContext.Database.EnsureCreated();
            }

            var availableServece = DbContext.Services.FirstOrDefault(service => service.Key == SystemServices._available);
            if (availableServece == null)
            {
                foreach (var service in SystemServices.All.Values)
                {
                    DbContext.Services.Add(service);
                }

                DbContext.SaveChanges();
            }
        }
    }
}