using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alpha.Models;
using alpha.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alpha.Controllers
{
    public class ItemController : Controller
    {
        private readonly IMealService mealService;
        public ItemController(IMealService mealService)
        {
            this.mealService = mealService;
        }
        // GET: /<controller>/
        public IActionResult Index(Guid dishId)
        {
            return View("Index", new Item() {DishId = dishId});
        }

        [HttpPost()]
        public IActionResult AddItem([FromForm] Item item)
        {
            var itemId = mealService.AddItemToDish(item);
            return RedirectToAction("Index", "Dish", new {id = item.DishId});
        }
    }
}
