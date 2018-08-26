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
        Dish AddDish(Dish dish);
        void UpdateDish(Dish dish);
        void DeleteDish(Guid id);
        Dish AddItemToDish(Item item);
        Dish GetDish(Guid dishId);
    }
    public class MealService: IMealService
    {
        public readonly IDishRepository dishRepo;
        private readonly IItemRepository itemRepo;

        public MealService(IDishRepository dishRepo, IItemRepository itemRepo)
        {
            this.dishRepo = dishRepo;
            this.itemRepo = itemRepo;
        }


        public Dish AddDish(Dish dish)
        {
            var dishId = dishRepo.Add(dish);
            var newDish = dishRepo.Get(dishId);
            return newDish;

        }

        public Dish AddItemToDish(Item item){
            var itemId = itemRepo.Add(item);
            var newItem = itemRepo.Get(itemId);
            var dish = dishRepo.Get(item.DishId);
            
            return dish;
        }

        public void DeleteDish(Guid id)
        {
            var dish = dishRepo.Get(id);
            dishRepo.Delete(dish);
        }

        public Dish GetDish(Guid dishId)
        {
            var dish = dishRepo.Get(dishId);
            return dish;
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
