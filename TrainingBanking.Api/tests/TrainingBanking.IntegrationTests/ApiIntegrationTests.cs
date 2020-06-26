using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Xunit;

namespace TrainingBanking.IntegrationTests
{
    public class ApiIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Should_Create_Account()
        {

            var content = "";

            var guid = Guid.NewGuid().ToString().Replace("-","").Substring(0, 11);
            var json = JsonConvert.SerializeObject(new
            {
                Name = $"Victor {guid}",
                Cpf = $"{guid}",
                Email = $"victor-{guid}@email.com.br",
                Phone = $"Phone {guid}",
                Address = $"Rua X.Y.Z {guid}"
            });
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("v1/Account/signup", stringContent);

            content = await response.Content.ReadAsStringAsync();

            Assert.IsFalse(string.IsNullOrEmpty(content));
            Assert.IsTrue(content.Contains("token"));
            Assert.IsTrue(content.Contains("user"));
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

        }

        [Fact]
        public async Task Should_Authentication()
        {

            var content = "";

            var guid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 11);
            var json = JsonConvert.SerializeObject(new
            {
                Name = $"Victor {guid}",
                Cpf = $"{guid}",
                Email = $"victor-{guid}@email.com.br",
                Phone = $"Phone {guid}",
                Address = $"Rua X.Y.Z {guid}"
            });
            
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            await _client.PostAsync("v1/Account/signup", stringContent);

            var json2 = JsonConvert.SerializeObject(new
            {
                Cpf = $"{guid}"
            });

            var stringContent2 = new StringContent(json2, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("v1/Account/signin", stringContent2);
            content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Assert.IsTrue(content.Contains("token"));
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

        }
    }
}
