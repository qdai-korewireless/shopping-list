using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using alpha;
using System.Threading.Tasks;
using FluentAssertions;

namespace alpha.e2e.tests
{

	public class HomeControllerTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public HomeControllerTests(WebApplicationFactory<Startup> factory){
            this._factory = factory;
        }

        [Theory]
        [InlineData("/Home/Index")]
        [InlineData("/Dish/Index")]
        [InlineData("/Item/Index")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.ToString().Should().Be("text/html; charset=utf-8");

        }

    }
}
