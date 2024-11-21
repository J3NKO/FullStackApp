using FullStackApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FullStackApp.Controllers
{
    public class ItemsController : Controller
    {

        //note here that there is only one Item controller controls all actions etc specific to the Item Model/View

        //This is a readonly variable which holds the data from the App Context file which holds the DbSet
        private readonly Data.AppContext _Context;

        public ItemsController(Data.AppContext context)
        {
            _Context = context;
        }

        public async Task<IActionResult> Index()
        {

            var item = await _Context.Items.Include(s => s.SerialNumber)
                                        .Include(c => c.Category)
                                        .Include(ic => ic.ItemClients)
                                        .ThenInclude(c => c.Client)
                                        .ToListAsync();


            //here we are sending the item data down to the Index View
            return View(item);

        }

        public IActionResult Create()
        {

            ViewData["Categories"] = new SelectList(_Context.Categories, "Id", "Name");

            return View();

        }


        //This is a post attribute which defines what the (request) below action method does


        //Bind to relavant Model
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price, CategoryId")] Item item)
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

            ViewData["Categories"] = new SelectList(_Context.Categories, "Id", "Name");

            var item = await _Context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price, CategoryId")] Item item)
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

        //Action methods for delete requests below

        public async Task<IActionResult> Delete(int id) {

            var item = await _Context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
                    
        }


        //Note that this uses a Post request and not a delete request due to code body of DeleteConfirmed method
        //But also delete requests cannot be triggered by form submissions!
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) { 
        
            var item = await _Context.Items.FindAsync(id);
            if (item != null) { 
            
                _Context.Items.Remove(item);
                await _Context.SaveChangesAsync();
            
            }
            return RedirectToAction("Index");

        }

    }
}
