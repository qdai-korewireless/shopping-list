using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using alpha;
using System.Threading.Tasks;
using FluentAssertions;
using alpha.e2e.tests.Helpers;

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

        [Theory]
        [InlineData("/Home/Index")]
        public async Task Index_CanAddDish_OnDishPage(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            var content = await HtmlHelpers.GetDocumentAsync(response);
            var addDishLink = content.QuerySelector("#lnkAddDish");
            var addDishUrl = addDishLink.GetAttribute("href");

            // Assert

            addDishUrl.Should().Be("/Dish/Index");

        }


    }
}
