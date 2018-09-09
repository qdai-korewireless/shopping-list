using System;
using System.Collections.Generic;
using alpha.Models;

namespace alpha.Services
{

    public interface IInventoryService{
        IList<Item> GetInventoryItems();
        void AddItem(Item item);
        void AddItems(IList<Item> items);
        void UpdateItem(Item item);
        void RemoveItem(Item item);
        void ClearInventory();

    }
    public class InventoryService: IInventoryService
    {
        public InventoryService()
        {
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void AddItems(IList<Item> items)
        {
            throw new NotImplementedException();
        }

        public void ClearInventory()
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetInventoryItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
