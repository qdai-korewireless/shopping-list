using System;
using alpha.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alpha.Controllers
{
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class HomeController : Controller
    {

        private readonly IMealService mealService;

        public HomeController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dishes = mealService.GetDishes();
            return View(dishes);
        }

        [HttpGet]
        public IActionResult DeleteDish(Guid id){
            mealService.DeleteDish(id);
            return RedirectToAction("Index");
        }



    }
}
