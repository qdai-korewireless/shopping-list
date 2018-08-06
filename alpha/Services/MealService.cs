using System;
using System.Collections.Generic;
using alpha.Models;

namespace alpha.Services
{

    public interface IMealService{
        IList<Dish> GetDishes();
        IList<Item> ShowItemsForDish(Dish dish);
    }
    public class MealService: IMealService
    {
        public MealService()
        {
        }

        public IList<Dish> GetDishes()
        {
            throw new NotImplementedException();
        }

        public IList<Item> ShowItemsForDish(Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}
