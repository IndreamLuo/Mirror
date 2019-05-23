using System.Collections.Generic;
using System.Linq;
using Moq;

namespace Mirror.UnitTest
{
    public static class TestHelper
    {
        public static Mock<TQueryable> MockQueryable<TQueryable, TItem>(IEnumerable<TItem> collection)
            where TQueryable : class, IQueryable<TItem>
        {
            var mockQueryable = new Mock<TQueryable>();
            
            var queryable = collection.AsQueryable();

            mockQueryable.As<IQueryable<TItem>>()
                .Setup(mock => mock.Provider)
                .Returns(queryable.AsQueryable().Provider);
            mockQueryable.As<IQueryable<TItem>>()
                .Setup(mock => mock.Expression)
                .Returns(queryable.AsQueryable().Expression);
            mockQueryable.As<IQueryable<TItem>>()
                .Setup(mock => mock.GetEnumerator())
                .Returns(queryable.GetEnumerator());

            return mockQueryable;
        }
    }
}