using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fridgeopolis.DataContext;
using Fridgeopolis.Models;

namespace Renipe.Controllers
{
    public class PropertyModelsController : Controller
    {
        private readonly RenipeDBContext _context;

        public PropertyModelsController(RenipeDBContext context)
        {
            _context = context;
        }

        // GET: PropertyModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.PropertyRecipe.ToListAsync());
        }

        // GET: PropertyModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PropertyRecipe == null)
            {
                return NotFound();
            }

            var propertyModel = await _context.PropertyRecipe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (propertyModel == null)
            {
                return NotFound();
            }

            return View(propertyModel);

            //return RedirectToAction("RecipeInfo/" + PropertyModel.ID, "Home");
        }

        // GET: PropertyModels/Create
        public IActionResult Create()
        {
            PropertyModel data = new PropertyModel()
            {
                ID = int.Parse(TempData["mydata"].ToString()),
                Title = TempData["mydata2"].ToString(),
                SourceUrl = TempData["mydata3"].ToString()
            };
            //PropertyModel data = TempData["mydata"] as PropertyModel;
            //var propertyModel = _context.RecipeData.FindAsync(data.ID);
            return View(data);
        }

        // POST: PropertyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,SourceUrl")] PropertyModel propertyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyModel);
        }

        // GET: PropertyModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PropertyRecipe == null)
            {
                return NotFound();
            }

            var propertyModel = await _context.PropertyRecipe.FindAsync(id);
            if (propertyModel == null)
            {
                return NotFound();
            }
            return View(propertyModel);
            //return View();
        }

        // POST: PropertyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,SourceUrl")] PropertyModel propertyModel)
        {
            if (id != propertyModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyModelExists(propertyModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(propertyModel);
            //return View();
        }

        // GET: PropertyModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PropertyRecipe == null)
            {
                return NotFound();
            }

            var propertyModel = await _context.PropertyRecipe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (propertyModel == null)
            {
                return NotFound();
            }

            return View(propertyModel);
        }

        // POST: PropertyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PropertyRecipe == null)
            {
                return Problem("Entity set 'RenipeDBContext.PropertyRecipe'  is null.");
            }
            var propertyModel = await _context.PropertyRecipe.FindAsync(id);
            if (propertyModel != null)
            {
                _context.PropertyRecipe.Remove(propertyModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyModelExists(int id)
        {
          return _context.PropertyRecipe.Any(e => e.ID == id);
        }
    }
}
