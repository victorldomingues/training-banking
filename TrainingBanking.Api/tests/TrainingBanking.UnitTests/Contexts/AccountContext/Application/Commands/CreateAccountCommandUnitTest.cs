using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CreateAccountCommandUnitTest
    {
        private INotifications _notifications;
        private readonly ITokenService _tokenService = new TokenService();
        private readonly IUsersRepository _usersRepository;
        private CreateAccountCommand _authenticateCommand;
        private List<User> Users = new List<User>();
        
        public CreateAccountCommandUnitTest()
        {
            var userRepository = new Mock<IUsersRepository>();

            userRepository.Setup(rep => rep.GetByCpf(It.IsAny<string>())).ReturnsAsync((string cpf) => Users.FirstOrDefault(x=>x.Cpf == cpf));
            
            userRepository.Setup(rep => rep.Add(It.IsAny<User>())).Returns((User user) =>
            {
                user.Id = Guid.NewGuid();
                Users.Add(user);
                return Task.CompletedTask;
            });

            _usersRepository = userRepository.Object;

            _notifications = new NotificationManager();
            _authenticateCommand = new CreateAccountCommand(_usersRepository, _notifications, _tokenService);

            Settings.SecurityKey = Guid.NewGuid().ToString();
            
        }

        [TestMethod]
        public void Should_Apply_Request_Treatment()
        {

            var request = new CreateAccountCommand.Request()
            {
                Cpf = "1/11.111.111-11\\",
                Address = "x.y.z",
                Email = "Email",
                Name = "Name",
                Phone = "Phone"
            };
            request.Treatment();
            Assert.AreEqual(request.Cpf, "11111111111");
            request = new CreateAccountCommand.Request()
            {
                Cpf = "",
                Address = "x.y.z",
                Email = "Email",
                Name = "Name",
                Phone = "Phone"
            };
            request.Treatment();

            Assert.AreEqual(request.Cpf, "");
        }

        [TestMethod]
        public void Should_Not_GenerateToken_With_Bad_Request()
        {
            
            var request = new CreateAccountCommand.Request();

            CreateAccountCommand.Response response = null;
            Task.Run(async () =>
            {
                response = await _authenticateCommand.Execute(request);
            }).GetAwaiter().GetResult();

            Assert.IsFalse(_notifications.IsValid());
            Assert.AreEqual(5, _notifications.Notifications.Count);
            Assert.IsTrue(string.IsNullOrEmpty(response.Token));
        }


        [TestMethod]
        public void Should_Request_Validating()
        {
        
            var request = new CreateAccountCommand.Request();

            _authenticateCommand.Validate(request);

            var keys = _notifications.Notifications.Select(x => x.Key).ToArray();

            Assert.AreEqual(5, _notifications.Notifications.Count);
            Assert.IsTrue(keys.Contains(nameof(request.Name)));
            Assert.IsTrue(keys.Contains(nameof(request.Cpf)));
            Assert.IsTrue(keys.Contains(nameof(request.Address)));
            Assert.IsTrue(keys.Contains(nameof(request.Email)));
            Assert.IsTrue(keys.Contains(nameof(request.Phone)));
        }

        [TestMethod]
        public void Should_Create_And_Return_Token()
        {

            var request = new CreateAccountCommand.Request()
            {
                Cpf = "11111111111",
                Address = "x.y.z",
                Email = "Email",
                Name = "Name",
                Phone = "Phone"
            };
            CreateAccountCommand.Response response = null;
            Task.Run(async () =>
            {
                response = await _authenticateCommand.Execute(request);
            }).GetAwaiter().GetResult();

            Assert.IsFalse(string.IsNullOrEmpty(response.Token));

        }


        [TestMethod]
        public void Should_Return_Existent_Account()
        {

            var request = new CreateAccountCommand.Request()
            {
                Cpf = "111.111.111-11",
                Address = "x.y.z",
                Email = "Email",
                Name = "Name",
                Phone = "Phone"
            };
            CreateAccountCommand.Response response = null;
            
            Task.Run(async () =>
            {
                response = await _authenticateCommand.Execute(request);
            }).GetAwaiter().GetResult();

            Assert.IsFalse(string.IsNullOrEmpty(response.Token));

            Task.Run(async () =>
            {
                response = await _authenticateCommand.Execute(request);
            }).GetAwaiter().GetResult();

            var keys = _notifications.Notifications.Select(x => x.Key).ToArray();

            Assert.IsTrue(keys.Contains(nameof(request.Cpf)));
            Assert.IsTrue(string.IsNullOrEmpty(response.Token));

        }

        [TestMethod]
        public void Should_Return_Not_Valid_Request()
        {

            var request = new CreateAccountCommand.Request()
            {
                Cpf = "99999999999",
                Address = "",
                Email = "Email",
                Name = "",
                Phone = "Phone"
            };
            CreateAccountCommand.Response response = null;
            Task.Run(async () =>
            {
                response = await _authenticateCommand.Execute(request);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(2, _notifications.Notifications.Count);

            Assert.IsTrue(string.IsNullOrEmpty(response.Token));

        }


    }
}
