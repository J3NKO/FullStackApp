using FullStackApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStackApp.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {

            var item = new Item() { 
            Name = "Keyboard"
            
            };

            return View(item); 
        }

        public IActionResult Edit(int id) {

            return Content("id= " + id);
        
        }

    }
}
