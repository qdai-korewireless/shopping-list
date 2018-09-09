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

        private readonly IMealService mealService;

        public DishController(IMealService mealService)
        {
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
            if(ModelState.IsValid){
                if (dish.Id != Guid.Empty)
                {
                    mealService.UpdateDish(dish);
                }
                else
                {
                    dish = mealService.AddDish(dish);
                }

                return RedirectToAction("Index", "Dish", new { id = dish.Id });
            }
            return View(ModelState);
        }


        [HttpPost()]
        public IActionResult Delete([FromForm]Guid id)
        {
            mealService.DeleteDish(id);
            return Ok();
        }
    }
}
