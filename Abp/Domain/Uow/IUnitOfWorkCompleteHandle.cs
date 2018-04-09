using System;
using System.Threading.Tasks;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// 用于完成一个工作单元
    /// 该接口不能被注入或直接使用。
    /// 用 <see cref="IUnitOfWorkManager"/> 替代.
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        /// <summary>
        /// 完成这个工作单元
        /// 它保存所有更改并提交交易（如果存在）
        /// </summary>
        void Complete();

        /// <summary>
        /// 完成这个工作单元
        /// 它保存所有更改并提交交易（如果存在）
        /// </summary>
        Task CompleteAsync();
    }
}