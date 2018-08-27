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
    [Route("[controller]/[action]")]
    public class DishController : Controller
    {

        private readonly IInventoryService inventoryService;
        private readonly IMealService mealService;

        public DishController(IInventoryService inventoryService, IMealService mealService)
        {
            this.inventoryService = inventoryService;
            this.mealService = mealService;
        }

        [HttpGet]
        public IActionResult Index(Guid ?id)
        {
            if(id.HasValue && id != Guid.Empty){
                var dish = mealService.GetDish(id.Value);
                return View("Index", dish);
            }
            return View("Index", new Dish() {Items = new List<Item>() {new Item()}});
        }

        [HttpPost()]
        public IActionResult Save([FromForm]Dish dish)
        {

            if(dish.Id != Guid.Empty){
                mealService.UpdateDish(dish);
            }
            else{
                dish = mealService.AddDish(dish);
            }

            return View("Index", dish);
        }


        [HttpPost()]
        public IActionResult Delete([FromForm]Guid id)
        {
            mealService.DeleteDish(id);
            return Ok();
        }
    }
}
