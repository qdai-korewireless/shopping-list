using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alpha.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alpha.Controllers
{
    public class HomeController : Controller
    {
        IInventoryService _inventoryService;
        public HomeController(IInventoryService inventoryService){
            _inventoryService = inventoryService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


    }
}
