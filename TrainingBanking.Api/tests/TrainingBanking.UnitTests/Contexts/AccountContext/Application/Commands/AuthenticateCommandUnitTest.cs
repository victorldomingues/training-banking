using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainingBanking.Application.AccountContext.Commands;
using TrainingBanking.Application.Services;
using TrainingBanking.Application.Services.Contracts;
using TrainingBanking.Domain.AccountContext.Entities;
using TrainingBanking.Domain.AccountContext.Repositories;
using TrainingBanking.Shared;
using TrainingBanking.Shared.Notifications;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.UnitTests.Contexts.AccountContext.Application.Commands
{
    [TestClass]
    public class AuthenticateCommandUnitTest
    {

        private readonly INotifications _notifications = new NotificationManager();
        private readonly ITokenService _tokenService = new TokenService();
        private readonly IUsersRepository _usersRepository;
        private readonly AuthenticateCommand _authenticateCommand;

        public AuthenticateCommandUnitTest()
        {
            var userRepository = new Mock<IUsersRepository>();
            userRepository.Setup(rep =>rep.GetByCpf("99999999999")).ReturnsAsync(() => new User()
            {
                Cpf = "99999999999",
                Name = "Teste",
                Address = "Rua teste",
                Phone = "11999999999",
                Id =Guid.NewGuid(),
                Email = "teste@teste.com"
            });
            _usersRepository = userRepository.Object; 
            Settings.SecurityKey = Guid.NewGuid().ToString();
            _authenticateCommand = new AuthenticateCommand(_usersRepository, _tokenService, _notifications);
        }

        
        [TestMethod]
        public void Should_Return_Token()
        {
            var request  =  new AuthenticateCommand.Request()
            {
                Cpf = "99999999999"
            };
            AuthenticateCommand.Response response = null;
            Task.Run(async () =>
            {
                response = await  _authenticateCommand.Execute(request);
                // Actual test code here.
            }).GetAwaiter().GetResult();

            Assert.IsFalse(string.IsNullOrEmpty(response.Token));

        }
    }
}
