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
        public IActionResult Index(Guid dishId, Guid ?itemId)
        {
            var item = new Item() { DishId = dishId, Id = itemId ?? Guid.Empty };

            if(itemId.HasValue){
                item = mealService.GetItem(itemId.Value);
            }


            return View("Index", item);
        }

        [HttpPost()]
        public IActionResult SaveItem([FromForm] Item item)
        {
            if(item.Id != Guid.Empty){
                mealService.UpdateItem(item);
            }
            else{
                var itemId = mealService.AddItemToDish(item);
            }

            return RedirectToAction("Index", "Dish", new {id = item.DishId});
        }

        [HttpGet]
        public IActionResult DeleteItem(Guid itemId){
            var item = mealService.GetItem(itemId);
            mealService.DeleteItem(itemId);
            return RedirectToAction("Index","Dish", new { id = item.DishId });
        }
    }
}
