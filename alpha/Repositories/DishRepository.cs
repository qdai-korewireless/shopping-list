using System;
using alpha.Models;
using Cassandra.Mapping;
using Cassandra;
using System.Collections.Generic;

namespace alpha.Repositories
{
    public interface IDishRepository : IRepository<Dish>{

    }
    public class DishRepository:IDishRepository
    {

        IMapper mapper;

        public DishRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Add(Dish item)
        {
            mapper.Insert(item);
        }

        public void Delete(Dish dish)
        {
            mapper.Delete(dish);
        }

        public Dish Get(int dishId)
        {       
            var dish = mapper.Single<Dish>("SELECT id, name FROM dish where id = ?", dishId);
            return dish;
        }

        public IEnumerable<Dish> GetAll()
        {
            return mapper.Fetch<Dish>();
        }

        public void Update(Dish item)
        {
            mapper.Update(item);
        }
    }

}
