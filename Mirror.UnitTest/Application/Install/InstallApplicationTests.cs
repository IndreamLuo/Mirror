using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Mirror.Application.Install;
using Mirror.Application.Service;
using Mirror.Data;
using Moq;
using NUnit.Framework;

namespace Mirror.UnitTest.Application.Install
{
    public class InstallApplicationTests : IInstanceTesting<InstallApplication, MirrorDbContext>
    {
        [Test]
        public void EnsureInstalled_SQLiteDb_NewDb()
        {
            var sqliteMirrorDbContextMock = new Mock<SQLiteMirrorDbContext>();

            var databaseFacadeMock = new Mock<DatabaseFacade>(sqliteMirrorDbContextMock.Object);
            databaseFacadeMock.Setup(facade => facade.EnsureCreated());
            sqliteMirrorDbContextMock.SetupGet(dbContext => dbContext.Database).Returns(databaseFacadeMock.Object);

            var servicesMock = TestHelper.MockQueryable<DbSet<Data.Entities.Service>, Data.Entities.Service>(new Data.Entities.Service[0]);
            servicesMock.Setup(services => services.Add(It.Is<Data.Entities.Service>(service => service.Key == SystemServices._available)));
            sqliteMirrorDbContextMock.Setup(dbContext => dbContext.SaveChanges());

            sqliteMirrorDbContextMock.SetupProperty(dbContext => dbContext.Services, servicesMock.Object);

            var installApplication = NewTestInstance(sqliteMirrorDbContextMock.Object);
            installApplication.EnsureInstalled();

            databaseFacadeMock.VerifyAll();
        }

        [Test]
        public void EnsureInstalled_SQLiteDb_AlreadyInstalled()
        {
            var sqliteMirrorDbContextMock = new Mock<SQLiteMirrorDbContext>();

            var databaseFacadeMock = new Mock<DatabaseFacade>(sqliteMirrorDbContextMock.Object);
            databaseFacadeMock.Setup(facade => facade.EnsureCreated());
            sqliteMirrorDbContextMock.SetupGet(dbContext => dbContext.Database).Returns(databaseFacadeMock.Object);

            var servicesMock = TestHelper.MockQueryable<DbSet<Data.Entities.Service>, Data.Entities.Service>(new []
            {
                new Data.Entities.Service
                {
                    Key = SystemServices._available
                }
            });

            sqliteMirrorDbContextMock.SetupProperty(dbContext => dbContext.Services, servicesMock.Object);

            var installApplication = NewTestInstance(sqliteMirrorDbContextMock.Object);
            installApplication.EnsureInstalled();

            databaseFacadeMock.VerifyAll();
        }
        
        public InstallApplication NewTestInstance(MirrorDbContext mirrorDbContext) => new InstallApplication(mirrorDbContext);
    }
}