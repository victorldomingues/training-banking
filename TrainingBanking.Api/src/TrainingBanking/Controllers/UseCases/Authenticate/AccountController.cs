using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingBanking.Application.AccountContext.Commands;
using TrainingBanking.Domain.Context;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.Controllers.UseCases.Authenticate
{
    public class AccountController :  BaseController
    {
        private readonly AuthenticateCommand _command;
        public AccountController(INotifications notifications, IUnitOfWork unitOfWork, AuthenticateCommand command) : base(notifications, unitOfWork)
        {
            _command = command;
        }

        [HttpPost, Route("signin")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticateCommand.Response>> Signin([FromBody] AuthenticateCommand.Request request)
        {
            return await Query(_command, request);
        }

    }
}
