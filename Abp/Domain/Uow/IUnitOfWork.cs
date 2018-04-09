namespace Abp.Domain.Uow
{
    /// <summary>
    /// 定义一个工作单元
    /// 该接口由ABP内部使用
    /// 用 <see cref="IUnitOfWorkManager.Begin()"/> 开始一个工作单元
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        /// UOW的标识
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Reference to the outer UOW if exists.
        /// </summary>
        IUnitOfWork Outer { get; set; }

        /// <summary>
        /// Begins the unit of work with given options.
        /// </summary>
        /// <param name="options">Unit of work options</param>
        void Begin(UnitOfWorkOptions options);
    }
}