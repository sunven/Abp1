using System.Data.Entity;
using Abp.MultiTenancy;

namespace Abp.EntityFramework.EntityFramework
{
    /// <summary>
    /// DbContext提供者的标准
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public interface IDbContextProvider<out TDbContext> where TDbContext : DbContext
    {
        TDbContext GetDbContext();

        TDbContext GetDbContext(MultiTenancySides? multiTenancySide);
    }
}