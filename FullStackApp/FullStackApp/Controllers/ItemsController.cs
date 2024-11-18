using FullStackApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackApp.Controllers
{
    public class ItemsController : Controller
    {

        //note here that there is only one Item controller controls all actions etc specific to the Item Model/View
        private readonly Data.AppContext _Context;

        public ItemsController(Data.AppContext context)
        {
            _Context = context;
        }

        public async Task<IActionResult> Index()
        {

            var item = await _Context.Items.ToListAsync();

            return View(item);

        }

        public IActionResult Create()
        {


            return View();

        }


        //This is a post attribute which defines what the (request) below action method does


        //Bind to relavant Model
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
        {

            if (ModelState.IsValid)
            {

                _Context.Items.Add(item);
                await _Context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            else
            {

                return View(item);

            }


        }

        public async Task<IActionResult> Edit(int id)
        {

            var item = await _Context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item)
        {

            if (ModelState.IsValid)
            {

                //Context is a reference to the actual data I defined in the Data.AppContext file
                _Context.Update(item);
                await _Context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            else
            {

                return View(item);

            }

        }
    }
}
