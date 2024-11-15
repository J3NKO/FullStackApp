using Microsoft.AspNetCore.Mvc;

namespace FullStackApp.Controllers
{
    public class ItemsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
