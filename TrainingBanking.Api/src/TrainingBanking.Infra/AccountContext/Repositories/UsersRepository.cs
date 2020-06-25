using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingBanking.Domain.AccountContext.Entities;
using TrainingBanking.Domain.AccountContext.Repositories;
using TrainingBanking.Infra.Context;
using TrainingBanking.Infra.Repositories;

namespace TrainingBanking.Infra.AccountContext.Repositories
{
    public class UsersRepository : Repository<User, Guid>, IUsersRepository
    {
        public UsersRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> GetByCpf(string cpf)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }
    }
}
