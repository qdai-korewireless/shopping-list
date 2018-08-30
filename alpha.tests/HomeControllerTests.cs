using System;
using System.Collections.Generic;
using alpha.Models;
using alpha.Services;
using Moq;
using Xunit;
using FluentAssertions;
using AutoFixture.Xunit2;
using alpha.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace alpha.tests
{
    public class HomeControllerTests
    {
        public HomeControllerTests()
        {
        }

        [Theory, AutoMoqData]
        public void Index_ShouldReturnsViewWithAllDishes([Frozen]IMealService mealService, [Frozen] IList<Dish> dishes)
        {
            //Arrange

            var mealMock = Mock.Get(mealService);
            mealMock.Setup(m => m.GetDishes()).Returns(dishes).Verifiable();
            var homeController = new HomeController(mealMock.Object);

            //Act

            var sut = homeController.Index();

            //Assert

            sut.Should().BeAssignableTo<IActionResult>()
               .And.BeOfType<ViewResult>()
               .Which.Model.Should().BeOfType<List<Dish>>()
               .Which.Should().HaveCount(dishes.Count);
            mealMock.Verify();


        }

        [Theory, AutoMoqData]
        public void DeleteDish_ShouldStayOnIndex_WhenDeleteADish([Frozen]IMealService mealService, [Frozen] Guid dishId)
        {
            //Arrange

            var mealMock = Mock.Get(mealService);
            mealMock.Setup(m => m.DeleteDish(dishId)).Verifiable();
            var homeController = new HomeController(mealMock.Object);

            //Act

            var sut = homeController.DeleteDish(dishId);

            //Assert

            sut.Should().BeAssignableTo<IActionResult>().And.BeOfType<RedirectToActionResult>()
               .Which.ActionName.Should().Be("Index");

            mealMock.Verify();


        }
    }
}
