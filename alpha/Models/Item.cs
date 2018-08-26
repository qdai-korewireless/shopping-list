using System;
using alpha.Repositories;

namespace alpha.Models
{
    public class Item: IIdentity
    {
        public Item()
        {
        }
        public Guid Id
        {
            get;
            set;
        }

        public Guid DishId
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
