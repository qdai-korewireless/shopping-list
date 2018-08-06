using System;
namespace alpha.Models
{
    public class Item
    {
        public Item()
        {
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
