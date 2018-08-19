using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alpha.Models;
using alpha.Services;
using Cassandra;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alpha.Controllers
{
    [Route("[controller]")]
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IInventoryService inventoryService;
        private readonly IMealService mealService;

        public HomeController(IInventoryService inventoryService, IMealService mealService)
        {
            this.inventoryService = inventoryService;
            this.mealService = mealService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var dishes = mealService.GetDishes();
            return View(dishes);
        }


    }
}
