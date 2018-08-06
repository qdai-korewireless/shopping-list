using System;
using System.Collections.Generic;

namespace alpha.Models
{
    public class Inventory
    {
        public Inventory()
        {
        }

        public IList<Item> Items
        {
            get;
            set;
        }
    }
}
