using System;
using System.Threading.Tasks;
using TrainingBanking.Domain.AccountContext.Entities;
using TrainingBanking.Shared.Repositories.Contracts;

namespace TrainingBanking.Domain.AccountContext.Repositories
{
    public  interface IUsersRepository : IRepository<User, Guid>
    {
       public Task<User> GetByCpf(string cpf);
    }
}
