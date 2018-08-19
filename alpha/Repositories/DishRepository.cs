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
       // Cluster myCassandraCluster;
        public DishRepository()
        {
            
        }

        public void Add(Dish item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Dish Get(int id)
        {
            var dishId = id;
            var myCassandraCluster = Cluster.Builder().AddContactPoint("localhost").Build();
            Dish dish = null;
            using (var session = myCassandraCluster.Connect("shoppingcart"))
            {

                IMapper mapper = new Mapper(session);
                dish = mapper.Single<Dish>("SELECT id, name FROM dish where id = ?", dishId);
            }

            return dish;
        }

        public IEnumerable<Dish> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Dish item)
        {
            throw new NotImplementedException();
        }
    }


}
