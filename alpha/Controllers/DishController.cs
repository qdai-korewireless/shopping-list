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
        public IActionResult Index()
        {
            var dish = mealService.GetDish(new Guid("0edd837b-0096-443a-a633-040311c6fde8"));
            return View("NewDish", new Dish() {Items = new List<Item>() {new Item()}});
        }

        [HttpPost()]
        public IActionResult Add([FromForm]Dish dish)
        {
            var newDish = mealService.AddDish(dish);
            return View("NewDish", newDish);
        }


        [HttpPost()]
        public IActionResult Delete([FromForm]Guid id)
        {
            mealService.DeleteDish(id);
            return Ok();
        }
    }
}
