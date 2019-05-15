using Mirror.Data;

namespace Mirror.Application.Install
{
    public interface IInstallApplication
    {
        void EnsureInstalled();
        
        void InitializeDb(MirrorDbContext dbContext);
    }
}