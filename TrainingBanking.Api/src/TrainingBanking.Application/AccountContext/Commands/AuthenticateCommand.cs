using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingBanking.Application.Services.Contracts;
using TrainingBanking.Domain.AccountContext.Repositories;
using TrainingBanking.Shared.Commands.Contracts;
using TrainingBanking.Shared.Notifications;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.Application.AccountContext.Commands
{
    public class AuthenticateCommand : ICommand<AuthenticateCommand.Request, AuthenticateCommand.Response>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenService _tokenService;
        private readonly INotifications _notifications;
        public AuthenticateCommand(IUsersRepository usersRepository, ITokenService tokenService, INotifications notifications)
        {
            _usersRepository = usersRepository;
            _tokenService = tokenService;
            _notifications = notifications;
        }

        public class Request
        {
            public string Cpf { get; set; }
        }
        public class Response
        {
            public string Token { get; set; }
            public IEnumerable<Notification> Errors { get; set; }
        }

        public async Task<Response> Execute(Request request)
        {
            Validate(request);
            var user = await _usersRepository.GetByCpf(request.Cpf);

            if (user == null)
                _notifications.Add($"O usuário com o CPF {request.Cpf} não foi econtrado na base de dados!", nameof(request.Cpf));

            if (!_notifications.IsValid())
                return new Response()
                {
                    Errors = _notifications.Notifications
                };

            var token = await _tokenService.GenerateToken(user);

            return new Response()
            {
                Token = token
            };
        }

        public void Validate(Request request)
        {
            if (string.IsNullOrEmpty(request.Cpf))
                _notifications.Add("O CPF deve ser informado", nameof(request.Cpf));

        }
    }
}
