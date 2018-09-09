using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using alpha1;
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

        //[Theory]
        //[InlineData("/Home/Index")]
        //public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    // Act
        //    var response = await client.GetAsync(url);

        //    // Assert
        //    response.EnsureSuccessStatusCode(); // Status Code 200-299
        //    response.Content.Headers.ContentType.ToString().Should().Be("text/html; charset=utf-8");

        //}

        //[Theory]
        //[InlineData("/Home/Index")]
        //public async Task Index_CanAddDish_OnDishPage(string url)
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    // Act
        //    var response = await client.GetAsync(url);
        //    var content = await HtmlHelpers.GetDocumentAsync(response);
        //    var addDishLink = content.QuerySelector("#lnkAddDish");
        //    var addDishUrl = addDishLink.GetAttribute("href");

        //    // Assert

        //    addDishUrl.Should().Be("/Dish/Index");

        //}
        //[Theory]
        //[InlineData("/Dish/Index")]
        //public async Task Get_DishIndex_StatusOK(string url)
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    // Act
        //    var response = await client.GetAsync(url);

        //    // Assert
        //    response.EnsureSuccessStatusCode(); // Status Code 200-299
        //    response.Content.Headers.ContentType.ToString().Should().Be("text/html; charset=utf-8");

        //}

        //[Theory]
        //[InlineData("/Dish/Index")]
        //public async Task Index_CanSubmitDish_OnDishPage(string url)
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    // Act
        //    var response = await client.GetAsync(url);
        //    var content = await HtmlHelpers.GetDocumentAsync(response);
        //    var frm = content.QuerySelector("#frmSaveDish");
        //    var frmData = new List<KeyValuePair<string, string>>() { KeyValuePair.Create<string, string>("Name", "e2eTest") };
        //    var addDishResponse = await client.SendAsync((IHtmlFormElement)frm, frmData);
        //    content = await HtmlHelpers.GetDocumentAsync(addDishResponse);
        //    var dishIdEle = (IHtmlInputElement)content.QuerySelector("#dishId");
        //    var dishId = new Guid(dishIdEle.Value);
        //    // Assert

        //    dishId.Should().NotBe(Guid.Empty);

        //}


        [Fact]
        public async Task Add_Dish_with_Two_Items()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act

            //Go to Home page
            var homePage = await client.GetContentAsync("Home/Index");

            //Find Add Dish link
            var lnkAddDish = homePage.QuerySelector("#lnkAddDish").As<IHtmlAnchorElement>();
            lnkAddDish.Should().NotBeNull();

            //Go to Add Dish page
            var dishPage = await client.GetContentAsync(lnkAddDish.Href);

            //Find Save Dish button
            var btnSaveDish = dishPage.QuerySelector("input[id=btnSaveDish]").As<IHtmlInputElement>();
            btnSaveDish.Should().NotBeNull();

            //Add a new Dish
            var dishForm = dishPage.QuerySelector("#frmSaveDish").As<IHtmlFormElement>();
            var dishPageNew = await client.SendAsyncGetContent(dishForm, btnSaveDish,new { Name = "e2eTest2"});

            //Find add Item link
            var lnkAddItem = dishPageNew.QuerySelector("#lnkAddItem").As<IHtmlAnchorElement>();
            lnkAddItem.Should().NotBeNull();

            //Go add item
            //var dishId = dishPageNew.QuerySelector("#dishId").As<IHtmlInputElement>();
            var itemPage = await client.GetContentAsync(lnkAddItem.Href);

            //add new item
            var btnNewItem = itemPage.QuerySelector("input[id=btnAddItem]").As<IHtmlInputElement>();
            btnNewItem.Should().NotBeNull();
            var itemForm = itemPage.QuerySelector("#frmItem").As<IHtmlFormElement>();
            var dishPageWithItem = await client.SendAsyncGetContent(itemForm, btnNewItem, new { Name = "e2eNewItem", Quantity = 2, Type = "Meat" });


            // Assert

            //dishId.Should().NotBe(Guid.Empty);

        }

    }
}
