using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrainingBanking.Shared.Repositories.Contracts
{
    public interface IRepository<TEntity, TKey> where TEntity : class 
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> Get(TKey id);
        Task<IEnumerable<TEntity>> All();
    }
}
