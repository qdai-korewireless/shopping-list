﻿using System;
using alpha.Models;
using Cassandra.Mapping;
using Cassandra;
using System.Collections.Generic;
using System.Linq;

namespace alpha.Repositories
{
    public interface IDishRepository : IRepository<Dish>{

    }
    public class DishRepository:IDishRepository
    {

        IMapper mapper;

        public DishRepository(IRe mapper)
        {
            this.mapper = mapper;
        }

        public Guid Add(Dish item)
        {
            item.Id = Guid.NewGuid();
            mapper.Insert(item);
            return item.Id;
        }

        public void Delete(Dish dish)
        {
            mapper.Delete(dish);
        }

        public Dish Get(Guid dishId)
        {       
            var dish = mapper.Single<Dish>("SELECT id, name FROM dish where id = ?", dishId);
            return dish;
        }

        public IEnumerable<Dish> GetAll()
        {
            var allItems = mapper.Fetch<Item>().ToList();

            var allDishes = mapper.Fetch<Dish>().ToList();

            allDishes.ForEach(d => {
                d.Items = allItems.Where(i => i.DishId == d.Id).ToList();
            });

            return allDishes;
        }

        public void Update(Dish item)
        {
            mapper.Update(item);
        }
    }

}
