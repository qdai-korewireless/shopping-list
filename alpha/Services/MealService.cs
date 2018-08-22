using System;
using System.Collections.Generic;
using System.Linq;
using alpha.Models;
using alpha.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace alpha.Services
{

    public interface IMealService{
        IList<Dish> GetDishes();
        IList<Item> ShowItemsForDish(Dish dish);
        void AddDish(Dish dish);
        void UpdateDish(Dish dish);
        void DeleteDish(int id);

    }
    public class MealService: IMealService
    {
        public readonly IDishRepository dishRepo;

        public MealService(IDishRepository dishRepo)
        {
            this.dishRepo = dishRepo;
        }


        public void AddDish(Dish dish)
        {
            dishRepo.Add(dish);
        }

        public void DeleteDish(int id)
        {
            var dish = dishRepo.Get(id);
            dishRepo.Delete(dish);
        }

        public IList<Dish> GetDishes()
        {
            return dishRepo.GetAll()?.ToList();
        }

        public IList<Item> ShowItemsForDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void UpdateDish(Dish dish)
        {
            dishRepo.Update(dish);
        }
    }
}
