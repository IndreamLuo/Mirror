using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mirror.Data;
using Mirror.Data.Entities;
using Moq;

namespace Mirror.UnitTest.Mock.Data
{
    public static class DbContextMocking
    {
        public static Mock<TDbContext> NewDbContext<TDbContext>(this Mocks mocks)
            where TDbContext : DbContext
        {
            var mock = new Mock<TDbContext>();
            mocks.Add(mock);
            return mock;
        }

        public static Mock<TDbContext> WithDbSet<TDbContext, TEntity>(this Mock<TDbContext> mock, Expression<Func<TDbContext, DbSet<TEntity>>> expression, DbSet<TEntity> dbSet)
            where TDbContext : DbContext
            where TEntity : Entity
        {
            mock.Setup(expression).Returns(dbSet);

            return mock;
        }

        public static Mock<TDbContext> SavedChanges<TDbContext>(this Mock<TDbContext> mock)
            where TDbContext : DbContext
        {
            mock.Setup(context => context.SaveChanges());
            return mock;
        }
    }
}