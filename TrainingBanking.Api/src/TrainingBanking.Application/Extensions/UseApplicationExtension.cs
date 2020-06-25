using Microsoft.Extensions.DependencyInjection;
using TrainingBanking.Application.AccountContext.Commands;
using TrainingBanking.Application.Services;
using TrainingBanking.Application.Services.Contracts;

namespace TrainingBanking.Application.Extensions
{
    public  static class UseApplicationExtension
    {
        public static void UseApplication(this IServiceCollection services)
        {
            services.AddTransient<CreateAccountCommand>();
            services.AddTransient<AuthenticateCommand>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
