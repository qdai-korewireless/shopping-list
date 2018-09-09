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
        Guid AddItemToDish(Item item);
        Dish GetDish(Guid dishId);
        Item GetItem(Guid id);
        void DeleteItem(Guid id);
        void UpdateItem(Item item);
    }
    public class MealService: IMealService
    {
        private readonly IRepository<Dish> dishRepo;
        private readonly IRepository<Item> itemRepo;

        public MealService(IRepository<Dish> dishRepo, IRepository<Item> itemRepo)
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

        public Guid AddItemToDish(Item item){
            if(item.DishId == null || item.DishId == Guid.Empty){
                return Guid.Empty;
            }
            var itemId = itemRepo.Add(item);
            return itemId;
        }

        public void DeleteDish(Guid id)
        {
            var dish = dishRepo.Get(id);
            var items = itemRepo.GetBy("where dishid = ?", id).ToList();
            if(dish.Id !=null && dish.Id != Guid.Empty){
                dishRepo.Delete(dish);
                items.ForEach(i => itemRepo.Delete(i));
            }
        }

        public void DeleteItem(Guid id)
        {
            var item = itemRepo.Get(id);
            itemRepo.Delete(item);
        }

        public Dish GetDish(Guid dishId)
        {
            var dish = dishRepo.Get(dishId);
            var items = itemRepo.GetBy("where dishid = ?", dishId);
            dish.Items = items.ToList();
            return dish;
        }

        public IList<Dish> GetDishes()
        {
            var dishes = dishRepo.GetAll()?.ToList();
            var items = itemRepo.GetAll().ToList();
            dishes.ForEach(d => d.Items = items.Where(i => i.DishId == d.Id).ToList());
            return dishes;
        }

        public Item GetItem(Guid id)
        {
            var item = itemRepo.Get(id);
            return item;
        }

        public IList<Item> ShowItemsForDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void UpdateDish(Dish dish)
        {
            dishRepo.Update(dish);
        }

        public void UpdateItem(Item item)
        {
            itemRepo.Update(item);
        }
    }
}
