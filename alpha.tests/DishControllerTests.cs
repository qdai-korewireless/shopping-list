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
    public class DishControllerTests
    {
        public DishControllerTests()
        {
        }

        [Theory, AutoMoqData]
        public void Index_ReturnsNewDish_WhenNotDishId([Frozen]IMealService mealService)
        {
            //Arrange

            var mealMock = Mock.Get(mealService);
            var dishController = new DishController(mealMock.Object);

            //Act

            var sut = dishController.Index(null);

            //Assert

            sut.Should().BeAssignableTo<IActionResult>().And.BeOfType<ViewResult>()
               .Which.Model.Should().NotBeNull().And.BeOfType<Dish>();


            mealMock.Verify();

        }

        [Theory, AutoMoqData]
        public void Index_ReturnsExistingDish_WhenPassExistingDishId([Frozen]IMealService mealService, [Frozen] Dish dish)
        {
            //Arrange

            var mealMock = Mock.Get(mealService);
            mealMock.Setup(m => m.GetDish(dish.Id)).Returns(dish).Verifiable();
            var dishController = new DishController(mealMock.Object);

            //Act

            var sut = dishController.Index(dish.Id);

            //Assert

            sut.Should().BeAssignableTo<IActionResult>().And.BeOfType<ViewResult>()
               .Which.Model.Should().NotBeNull().And.BeOfType<Dish>()
               .Which.Should().BeSameAs(dish);

            mealMock.Verify();

        }

        [Theory, AutoMoqData]
        public void Save_ReturnsToIndexWithDish_WhenSaveNewDish([Frozen]IMealService mealService, [Frozen] Dish dish)
        {
            //Arrange
            dish.Id = Guid.Empty;

            var mealMock = Mock.Get(mealService);
            mealMock.Setup(m => m.AddDish(dish)).Returns(dish).Verifiable();
            var dishController = new DishController(mealMock.Object);

            //Act

            var sut = dishController.Save(dish);

            //Assert
            sut.Should().BeOfType<RedirectToActionResult>().Which.ActionName.Should().Be("Index");
            sut.Should().BeAssignableTo<IActionResult>().And.BeOfType<RedirectToActionResult>()
               .Which.RouteValues.Should().NotBeNull().And.ContainValue(dish.Id);
              

            mealMock.Verify();

        }

        [Theory, AutoMoqData]
        public void Save_ReturnsToIndexWithDish_WhenSaveExistingDish([Frozen]IMealService mealService, [Frozen] Dish dish)
        {
            //Arrange

            var mealMock = Mock.Get(mealService);
            mealMock.Setup(m => m.UpdateDish(dish)).Verifiable();
            var dishController = new DishController(mealMock.Object);

            //Act

            var sut = dishController.Save(dish);

            //Assert
            sut.Should().BeOfType<RedirectToActionResult>().Which.ActionName.Should().Be("Index");
            sut.Should().BeAssignableTo<IActionResult>().And.BeOfType<RedirectToActionResult>()
               .Which.RouteValues.Should().NotBeNull().And.ContainValue(dish.Id);


            mealMock.Verify();

        }
        [Theory, AutoMoqData]
        public void Save_ReturnsViewWithModelStateError_WhenSaveDishWithoutName([Frozen]IMealService mealService, [Frozen] Dish dish)
        {
            //Arrange
            dish.Name = "";

            var mealMock = Mock.Get(mealService);
            var dishController = new DishController(mealMock.Object);
            dishController.ModelState.AddModelError("Name", "Required");

            //Act

            var sut = dishController.Save(dish);
            

            //Assert

            sut.Should().BeAssignableTo<IActionResult>().And.BeOfType<ViewResult>()
               .Which.ViewData.ModelState["Name"].Errors.Should().HaveCount(1);


        }
    }
}
