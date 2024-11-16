using FullStackApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStackApp.Controllers
{
    public class ItemsController1 : Controller
    {
        public IActionResult Overview()
        {

            var item = new Item() { 
            Name = "Keyboard"
            
            };

            return View(item); 
        }
    }
}
