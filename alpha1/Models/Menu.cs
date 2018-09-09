using System;
using System.Collections.Generic;

namespace alpha.Models
{
    public class Menu
    {
        public Menu()
        {
        }

        public string Name
        {
            get;
            set;
        }

        public IList<Dish> Dishes
        {
            get;
            set;
        }
    }
}
