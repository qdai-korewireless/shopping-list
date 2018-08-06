using System;
using System.Collections.Generic;

namespace alpha.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public IList<Item> ItemChecklist
        {
            get;
            set;
        }

        public IList<Item> BoughtItems
        {
            get;
            set;
        }
    }
}
