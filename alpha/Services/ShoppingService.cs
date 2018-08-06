using System;
using System.Collections.Generic;
using alpha.Models;

namespace alpha.Services
{
    public interface IShoppingService
    {
        void AddItemsToCart(IList<Item> items);
        void CheckItem(Item item);
        IList<Item> GetBoughtItems();
        void ClearCart();
    }
    public class ShoppingService: IShoppingService
    {
        public ShoppingService()
        {
        }

        public void AddItemsToCart(IList<Item> items)
        {
            throw new NotImplementedException();
        }

        public void CheckItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetBoughtItems()
        {
            throw new NotImplementedException();
        }
    }
}
