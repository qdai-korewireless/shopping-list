using System;
using System.Collections.Generic;

namespace alpha.Models
{
    public class Dish
    {
        public Dish()
        {
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public IList<Item> Items
        {
            get;
            set;
        }


    }
}
