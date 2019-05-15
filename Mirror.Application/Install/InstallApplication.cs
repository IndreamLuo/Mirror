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

        }

        public void InitializeDb(MirrorDbContext dbContext)
        {
            if (dbContext is SQLiteMirrorDbContext)
            {
                if (dbContext.Database.EnsureCreated())
                {
                    
                }
            }
        }
    }
}