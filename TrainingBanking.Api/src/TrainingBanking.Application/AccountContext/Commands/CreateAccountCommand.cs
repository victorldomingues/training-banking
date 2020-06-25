using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingBanking.Application.Services.Contracts;
using TrainingBanking.Domain.AccountContext.Dtos;
using TrainingBanking.Domain.AccountContext.Entities;
using TrainingBanking.Domain.AccountContext.Repositories;
using TrainingBanking.Shared.Commands.Contracts;
using TrainingBanking.Shared.Notifications;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.Application.AccountContext.Commands
{

    public class CreateAccountCommand : ICommand<CreateAccountCommand.Request, CreateAccountCommand.Response>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly INotifications _notifications;
        private readonly ITokenService _tokenService;

        public CreateAccountCommand(IUsersRepository usersRepository, INotifications notifications, ITokenService tokenService)
        {
            _usersRepository = usersRepository;
            _notifications = notifications;
            _tokenService = tokenService;
        }

        public class Request
        {
            public string Cpf { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }

            //todo: Uma melhor implementação seria com auto mapper
            public User ToUser()
            {
                return new User()
                {
                    Cpf = string.IsNullOrEmpty(Cpf) ? Cpf : Cpf
                        .Replace(".","")
                        .Replace(" ", "")
                        .Replace("-", "")
                        .Replace("\\",""),
                    Email = Email,
                    Phone = Phone,
                    Address = Address,
                    Name = Name
                };
            }
        }

        public class Response
        {
            public UserDto User { get; set; }
            public string Token { get; set; }
            public IEnumerable<Notification> Errors { get; set; }
        }

        public async Task<Response> Execute(Request request)
        {

            Validate(request);

            var user = await _usersRepository.GetByCpf(request.Cpf);

            if (user != null)
                _notifications.Add($"Já existe um usuário com o cpf {request.Cpf}.", nameof(Request.Cpf));

            if (!_notifications.IsValid())
            {
                return new Response()
                {
                    Errors = _notifications.Notifications
                };
            }

            user = request.ToUser();

            await _usersRepository.Add(user);

            var token = await _tokenService.GenerateToken(user);

            return new Response()
            {
                User = UserDto.From(user),
                Token = token,
                Errors = _notifications.Notifications
            };
        }

        private void  Validate(Request request)
        {
            if (string.IsNullOrEmpty(request.Name))
                _notifications.Add("O Nome deve ser informado", nameof(request.Name));

            if (string.IsNullOrEmpty(request.Cpf))
                _notifications.Add("O CPF deve ser informado", nameof(request.Cpf));

            if (string.IsNullOrEmpty(request.Address))
                _notifications.Add("O Endereço deve ser informado", nameof(request.Address));

            if (string.IsNullOrEmpty(request.Email))
                _notifications.Add("O E-mail deve ser informado", nameof(request.Email));

            if (string.IsNullOrEmpty(request.Phone))
                _notifications.Add("O Telefone deve ser informado", nameof(request.Phone));
        }
    }
}
