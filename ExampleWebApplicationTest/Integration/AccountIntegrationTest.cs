using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ExampleWebApplicationTest.Integration
{
    public sealed class BasicIntegrationTest : IntegrationTest
    {
        private readonly TestWebApplicationFactory<TestStartup> _factory;

        public BasicIntegrationTest(TestWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_SecurePageRedirectsAnUnauthenticatedUser()
        {
            // Arrange
            var client = GetClient(false);

            // Act
            var response = await client.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("Account/Login",
                response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task ShouldLoginAndRenderHome()
        {
            //Arrange
            var client = GetClient();
            await PerformLogin(client, TestSeedData.TestEmail, TestSeedData.TestPassword);

            //Act
            var response = await client.GetAsync("/");
            var body = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Home", body);
        }

        private HttpClient GetClient(Boolean redirects = true)
        {
            return _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = redirects
            });
        }
    }
}