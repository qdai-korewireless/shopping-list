using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using alpha;
using System.Threading.Tasks;
using FluentAssertions;
using alpha.e2e.tests.Helpers;
using System.Collections.Generic;
using AngleSharp.Dom.Html;

namespace alpha.e2e.tests
{

	public class AllTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AllTests(WebApplicationFactory<Startup> factory){
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
        [Theory]
        [InlineData("/Dish/Index")]
        public async Task Get_DishIndex_StatusOK(string url)
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
        [InlineData("/Dish/Index")]
        public async Task Index_CanSubmitDish_OnDishPage(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            var content = await HtmlHelpers.GetDocumentAsync(response);
            var frm = content.QuerySelector("#frmSaveDish");
            var frmData = new List<KeyValuePair<string, string>>() { KeyValuePair.Create<string, string>("Name", "e2eTest") };
            var addDishResponse = await client.SendAsync((IHtmlFormElement)frm, frmData);
            content = await HtmlHelpers.GetDocumentAsync(addDishResponse);
            var dishIdEle = (IHtmlInputElement)content.QuerySelector("#dishId");
            var dishId = new Guid(dishIdEle.Value);
            // Assert

            dishId.Should().NotBe(Guid.Empty);

        }

    }
}
