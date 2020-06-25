using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingBanking.Application.AccountContext.Commands;
using TrainingBanking.Domain.AccountContext.Repositories;
using TrainingBanking.Domain.Context;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.Controllers.UseCases.CreateAccount
{
    public class AccountController : BaseController
    {

        private readonly CreateAccountCommand _command;
        private readonly IUsersRepository _usersRepository;

        public AccountController(INotifications notifications, 
            IUnitOfWork unitOfWork, CreateAccountCommand command, 
            IUsersRepository usersRepository) : base(notifications, unitOfWork)
        {
            _command = command;
            _usersRepository = usersRepository;
        }

        [HttpPost, Route("signup"), AllowAnonymous]
        public async Task<ActionResult<CreateAccountCommand.Response>> SignUp([FromBody] CreateAccountCommand.Request request)
        {
            return await Execute(_command, request);
        }

        [HttpGet, Route("")]
        public async Task<ActionResult<object>> Get()
        {
            return (dynamic) new {x = "teste"};
        }
    }
}
