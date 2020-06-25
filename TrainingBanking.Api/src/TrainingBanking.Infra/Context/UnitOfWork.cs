using System.Threading.Tasks;
using TrainingBanking.Domain.Context;

namespace TrainingBanking.Infra.Context
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<int> Commit()
        {
            return await _applicationContext.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _applicationContext?.Dispose();
        }
    }
}
