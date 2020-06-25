using System.Threading.Tasks;
using TrainingBanking.Domain.AccountContext.Entities;

namespace TrainingBanking.Application.Services.Contracts
{
    public interface ITokenService
    {
        /// <summary>
        /// Gera o token do usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Token</returns>
        Task<string> GenerateToken(User user);
    }
}
