using System;
namespace alpha.Models
{
    public class Item
    {
        public Item()
        {
        }
        public int Id
        {
            get;
            set;
        }

        public int DishId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public ItemType Type
        {
            get;
            set;
        }

    }
}
