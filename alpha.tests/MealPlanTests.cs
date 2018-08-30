using System.Collections.Generic;
using alpha.Models;
using alpha.Services;
using Moq;
using Xunit;
using FluentAssertions;
using AutoFixture.Xunit2;
using alpha.Repositories;
using System.Linq;

namespace alpha.tests
{
    public class MealPlanTests
    {
        
        public MealPlanTests(){
            
        }

        [Theory, AutoMoqData]
        public void GetAllDishes_CallRepo_GetAll([Frozen]IRepository<Dish> dishRepo,MealService mealService)
        {
            // Setup
            var dishRepoMock = Mock.Get(dishRepo);

            // Action
            var dishes = mealService.GetDishes();

            // Assert
            dishRepoMock.Verify(m => m.GetAll());

        }

    }


}
