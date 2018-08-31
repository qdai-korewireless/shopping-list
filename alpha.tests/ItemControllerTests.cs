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
    public class ItemControllerTests
    {
        public ItemControllerTests()
        {
        }

        [Theory, AutoMoqData]
        public void Index_ReturnsViewWithItemAndDishId_WhenPassDishId([Frozen]IMealService mealService, [Frozen] Guid dishId)
        {
            //Arrange

            var mealMock = Mock.Get(mealService);
            var itemController = new ItemController(mealMock.Object);


            //Act

            var sut = itemController.Index(dishId);


            //Assert

            sut.Should()
               .BeAssignableTo<IActionResult>().And
               .BeOfType<ViewResult>()
               .Which.Model.Should().BeOfType<Item>()
               .Which.DishId.Should().Be(dishId);


        }

        [Theory, AutoMoqData]
        public void AddItem_RedirectToDishIndex_WhenPassItem([Frozen]IMealService mealService, [Frozen]Item item)
        {
            //Arrange

            var mealMock = Mock.Get(mealService);
            var itemController = new ItemController(mealMock.Object);


            //Act

            var sut = itemController.AddItem(item);


            //Assert

            sut.Should()
               .BeAssignableTo<IActionResult>().And
               .BeOfType<RedirectToActionResult>()
               .Which.RouteValues["id"].Should().Be(item.DishId);
            sut.Should()
               .BeOfType<RedirectToActionResult>()
               .Which.ActionName.Should().Be("Index");
            sut.Should()
               .BeOfType<RedirectToActionResult>()
               .Which.ControllerName.Should().Be("Dish");

            mealMock.Verify(m => m.AddItemToDish(item));

        }
    }
}
