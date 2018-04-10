using System.Data.Entity;

namespace Abp.EntityFramework.EntityFramework.Repositories
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}