using System.Collections.Generic;
using alpha.Models;
using alpha.Services;
using Moq;
using Xunit;
using FluentAssertions;
using AutoFixture.Xunit2;
using AutoFixture;
using AutoFixture.AutoMoq;
using alpha.Repositories;
using System.Linq;

namespace alpha.tests
{
    public class MealPlanTests
    {
        
        public MealPlanTests(){
            
        }
        [Theory, AutoMoqData]
        public void add_item_to_inventory(IInventoryService invService)
        {
            // Setup

            var inventory = invService;

            // Action

            inventory.AddItem(new Item { Name = "Milk", Quantity = 1, Type = ItemType.Drink });


            // Assert

            inventory.GetInventoryItems().Count.Should().Be(1);

        }

        [Theory, AutoMoqData]
        public void GetAllDishes_CallRepo_GetAll([Frozen]IDishRepository dishRepo,MealService mealService)
        {
            // Setup
            var dishRepoMock = Mock.Get(dishRepo);

            // Action
            var dishes = mealService.GetDishes();

            // Assert
            dishRepoMock.Verify(m => m.GetAll());

        }

        [Fact]
        public void adddish(){
            
        }

      




    }
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }

    public class InlineAutoMoqDataAttribute : CompositeDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] values)
            : base(new InlineDataAttribute(values), new AutoMoqDataAttribute())
        {
        }
    }


}
