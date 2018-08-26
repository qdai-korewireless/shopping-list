using System;
using System.Collections.Generic;
using alpha.Models;

namespace alpha.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {

    }
    public class ItemRepository:IItemRepository
    {
        IRepository<Item> repo;

        public ItemRepository(IRepository<Item> repo)
        {
            this.repo = repo;
        }

        public Guid Add(Item item)
        {
            return repo.Add(item);
        }

        public void Delete(Item item)
        {
            repo.Delete(item);
        }

        public Item Get(Guid id)
        {
            return repo.Get(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return repo.GetAll();
        }

        public void Update(Item item)
        {
            repo.Update(item);
        }
    }
}
