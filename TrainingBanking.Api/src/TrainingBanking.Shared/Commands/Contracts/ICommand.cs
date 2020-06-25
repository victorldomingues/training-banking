using System.Threading.Tasks;

namespace TrainingBanking.Shared.Commands.Contracts
{
    public interface ICommand<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        Task<TResponse> Execute(TRequest request);
    }
}
