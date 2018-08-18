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
        IInventoryService _inventoryService;
        public HomeController(IInventoryService inventoryService){
            _inventoryService = inventoryService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            var item = new Item();
            item.Name = "Apple";
            var myCassandraCluster = Cluster.Builder()
                                            .AddContactPoint("localhost")
    //.WithAuthProvider(new DsePlainTextAuthProvider("username", "password"))
    .Build();
            using (var session = myCassandraCluster.Connect("shoppingcart"))
            {
               
                var query = new SimpleStatement("SELECT id, name, quantity, typeid FROM item where id = ?", 1);
                var rs =  session.Execute(query);
                var row = rs.FirstOrDefault();
                if (row != null)
                {
                    var itemName = row.GetValue(typeof(string), 1);
                    item.Name = itemName.ToString();
                }
            }
            return View(item);
        }


    }
}
