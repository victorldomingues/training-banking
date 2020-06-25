using Microsoft.Extensions.DependencyInjection;
using TrainingBanking.Domain.AccountContext.Repositories;
using TrainingBanking.Domain.Context;
using TrainingBanking.Infra.AccountContext.Repositories;
using TrainingBanking.Infra.Context;

namespace TrainingBanking.Infra.Extensions
{
    public static class UseInfraExtension
    {
        public static void UseInfra(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
