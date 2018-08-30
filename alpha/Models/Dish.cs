using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using alpha.Repositories;

namespace alpha.Models
{
    public class Dish:IIdentity
    {
        public Dish()
        {
        }

        public Guid Id
        {
            get;
            set;
        }

        [Required]
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
