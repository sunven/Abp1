using System.Data.Entity;
using Abp.Domain.Uow;

namespace Abp.EntityFramework.EntityFramework.Uow
{
    public interface IEfUnitOfWorkFilterExecuter : IUnitOfWorkFilterExecuter
    {
        void ApplyCurrentFilters(IUnitOfWork unitOfWork, DbContext dbContext);
    }
}