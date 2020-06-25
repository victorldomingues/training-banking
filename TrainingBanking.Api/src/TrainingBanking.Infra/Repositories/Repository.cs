using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingBanking.Infra.Context;
using TrainingBanking.Shared.Repositories.Contracts;

namespace TrainingBanking.Infra.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected ApplicationContext Context;
        public Repository(ApplicationContext context)
        {
            Context = context;
        }
        public async Task Add(TEntity entity) => Context.Set<TEntity>().Add(entity);
        public async Task Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
        public async Task<TEntity> Get(TKey id) => await Context.Set<TEntity>().FindAsync(id);
        public async Task<IEnumerable<TEntity>> All() => await Context.Set<TEntity>().ToListAsync();
    }
}
