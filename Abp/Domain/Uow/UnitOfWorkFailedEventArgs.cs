using System;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// <see cref="IActiveUnitOfWork.Failed"/> 用此参数
    /// </summary>
    public class UnitOfWorkFailedEventArgs : EventArgs
    {
        /// <summary>
        /// 导致失败的异常
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Creates a new <see cref="UnitOfWorkFailedEventArgs"/> object.
        /// </summary>
        /// <param name="exception">Exception that caused failure</param>
        public UnitOfWorkFailedEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}