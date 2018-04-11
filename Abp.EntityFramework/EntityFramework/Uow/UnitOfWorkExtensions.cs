using System;
using System.Data.Entity;
using Abp.Domain.Uow;
using Abp.MultiTenancy;

namespace Abp.EntityFramework.EntityFramework.Uow
{
    /// <summary>
    /// UnitOfWork扩展
    /// </summary>
    public static class UnitOfWorkExtensions
    {
        /// <summary>
        /// 获取DbContext作为活动工作单元的一部分。
        /// 当前工作单元是<see cref ="EfUnitOfWork"/>时，可以调用此方法。
        /// </summary>
        /// <typeparam name="TDbContext">Type of the DbContext</typeparam>
        /// <param name="unitOfWork">Current (active) unit of work</param>
        public static TDbContext GetDbContext<TDbContext>(this IActiveUnitOfWork unitOfWork)
            where TDbContext : DbContext
        {
            return GetDbContext<TDbContext>(unitOfWork, null);
        }

        public static TDbContext GetDbContext<TDbContext>(this IActiveUnitOfWork unitOfWork, MultiTenancySides? multiTenancySide)
            where TDbContext : DbContext
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (!(unitOfWork is EfUnitOfWork))
            {
                throw new ArgumentException("unitOfWork is not type of " + typeof(EfUnitOfWork).FullName, nameof(unitOfWork));
            }

            return (unitOfWork as EfUnitOfWork).GetOrCreateDbContext<TDbContext>(multiTenancySide);
        }
    }
}