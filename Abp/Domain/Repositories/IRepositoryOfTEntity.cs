using Abp.Domain.Entities;

namespace Abp.Domain.Repositories
{
    /// <summary>
    /// 用int类型做主键的情况较多，单独一个Repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }
}