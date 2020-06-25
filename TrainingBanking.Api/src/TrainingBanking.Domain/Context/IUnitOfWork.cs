using System;
using System.Threading.Tasks;

namespace TrainingBanking.Domain.Context
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();
        Task Rollback();
    }
}
