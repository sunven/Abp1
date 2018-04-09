using System.Data.Entity;

namespace Abp.EntityFramework.EntityFramework
{
    /// <summary>
    /// 简单DbContext
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public sealed class SimpleDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        public TDbContext DbContext { get; }

        public SimpleDbContextProvider(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TDbContext GetDbContext()
        {
            return DbContext;
        }
    }
}