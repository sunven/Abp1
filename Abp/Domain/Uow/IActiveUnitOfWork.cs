using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// 活动工作单元接口
    /// 这个接口不能被注入
    /// 用 <see cref="IUnitOfWorkManager"/> 替代.
    /// </summary>
    public interface IActiveUnitOfWork
    {
        /// <summary>
        /// 当这个UOW成功完成时，这个事件就会发生
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// 此UOW失败时会引发此事件
        /// </summary>
        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// 这个事件在这个UOW被销毁时执行。
        /// </summary>
        event EventHandler Disposed;

        /// <summary>
        /// 获取这个工作单元的事务设置。
        /// </summary>
        UnitOfWorkOptions Options { get; }

        /// <summary>
        /// 获取此工作单元的数据过滤器配置。
        /// </summary>
        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        /// <summary>
        /// Is this UOW disposed?
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// 在此工作单元中保存所有更改。
        /// 可以调用此方法以在需要时应用更改。
        /// 请注意，如果此工作单元是事务性的，则如果事务回滚，则保存的更改也会回滚。
        /// SaveChanges通常不需要显式调用，
        /// 因为所有更改都会自动保存在工作单元末尾。
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Saves all changes until now in this unit of work.
        /// This method may be called to apply changes whenever needed.
        /// Note that if this unit of work is transactional, saved changes are also rolled back if transaction is rolled back.
        /// No explicit call is needed to SaveChanges generally, 
        /// since all changes saved at end of a unit of work automatically.
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// 禁用一个或多个数据过滤器。
        /// 如果过滤器已禁用，则不执行任何操作。
        /// 如果需要，在using语句中使用此方法重新启用筛选器。
        /// </summary>
        /// <param name="filterNames">One or more filter names. <see cref="AbpDataFilters"/> for standard filters.</param>
        /// <returns>A <see cref="IDisposable"/> handle to take back the disable effect.</returns>
        IDisposable DisableFilter(params string[] filterNames);

        /// <summary>
        /// Enables one or more data filters.
        /// Does nothing for a filter if it's already enabled.
        /// Use this method in a using statement to re-disable filters if needed.
        /// </summary>
        /// <param name="filterNames">One or more filter names. <see cref="AbpDataFilters"/> for standard filters.</param>
        /// <returns>A <see cref="IDisposable"/> handle to take back the enable effect.</returns>
        IDisposable EnableFilter(params string[] filterNames);

        /// <summary>
        /// Checks if a filter is enabled or not.
        /// </summary>
        /// <param name="filterName">Name of the filter. <see cref="AbpDataFilters"/> for standard filters.</param>
        bool IsFilterEnabled(string filterName);

        /// <summary>
        /// 设置（覆盖）过滤器参数的值。
        /// </summary>
        /// <param name="filterName">Name of the filter</param>
        /// <param name="parameterName">Parameter's name</param>
        /// <param name="value">Value of the parameter to be set</param>
        IDisposable SetFilterParameter(string filterName, string parameterName, object value);

        /// <summary>
        /// 设置/更改此UOW的租户ID。
        /// </summary>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns>A disposable object to restore old TenantId value when you dispose it</returns>
        IDisposable SetTenantId(int? tenantId);

        /// <summary>
        /// 设置/更改此UOW的租户ID。
        /// </summary>
        /// <param name="tenantId">The tenant id</param>
        /// <param name="switchMustHaveTenantEnableDisable">
        /// True to enable/disable <see cref="IMustHaveTenant"/> based on given tenantId.
        /// Enables <see cref="IMustHaveTenant"/> filter if tenantId is not null.
        /// Disables <see cref="IMustHaveTenant"/> filter if tenantId is null.
        /// This value is true for <see cref="SetTenantId(int?)"/> method.
        /// </param>
        /// <returns>A disposable object to restore old TenantId value when you dispose it</returns>
        IDisposable SetTenantId(int? tenantId, bool switchMustHaveTenantEnableDisable);

        /// <summary>
        /// Gets Tenant Id for this UOW.
        /// </summary>
        /// <returns></returns>
        int? GetTenantId();
    }
}