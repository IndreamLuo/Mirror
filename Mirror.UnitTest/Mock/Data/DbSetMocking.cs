using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mirror.Data.Entities;
using Moq;

namespace Mirror.UnitTest.Mock.Data
{
    public static class DbSetMocking
    {
        public static Mock<DbSet<TEntity>> NewDbSet<TEntity>(this Mocks mocks)
            where TEntity : Entity
        {
            var dbSetMock = new Mock<DbSet<TEntity>>();
            mocks.Add(dbSetMock);
            return dbSetMock;
        }

        public static Mock<DbSet<TEntity>> IsEnumerable<TEntity>(this Mock<DbSet<TEntity>> mock, IEnumerable<TEntity> source)
            where TEntity : Entity
        {
            var queryable = source.AsQueryable();

            // mock.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(queryable.Provider);
            // mock.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(queryable.Expression);
            // mock.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mock.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return mock;
        }

        public static Mock<DbSet<TEntity>> CanAddTo<TEntity>(this Mock<DbSet<TEntity>> mock, ICollection<TEntity> source)
            where TEntity : Entity
        {
            mock.Setup(dbSet => dbSet.Add(It.IsAny<TEntity>())).Callback<TEntity>(value => source.Add(value));
            return mock;
        }
    }
}