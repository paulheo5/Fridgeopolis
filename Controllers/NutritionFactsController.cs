using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fridgeopolis.DataContext;
using Fridgeopolis.Models;

namespace Fridgeopolis.Controllers
{
    public class NutritionFactsController : Controller
    {
        private readonly RecipeDBContext _context;

        public NutritionFactsController(RecipeDBContext context)
        {
            _context = context;
        }

        // GET: NutritionFacts
        public async Task<IActionResult> Index()
        {
              return View(await _context.NutritionData.ToListAsync());
        }

        // GET: NutritionFacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NutritionData == null)
            {
                return NotFound();
            }

            var nutritionFacts = await _context.NutritionData
                .FirstOrDefaultAsync(m => m.NutritionId == id);
            if (nutritionFacts == null)
            {
                return NotFound();
            }

            return View(nutritionFacts);
        }

        // GET: NutritionFacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NutritionFacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NutritionId,FoodName,CaloriesPerServing,CarbohydratesPerServing,ProteinPerServing,FatPerServing,PhosphorusPerServing,PotassiumPerServing,SodiumPerServing,Servings,Date")] NutritionFacts nutritionFacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nutritionFacts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nutritionFacts);
        }

        // GET: NutritionFacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NutritionData == null)
            {
                return NotFound();
            }

            var nutritionFacts = await _context.NutritionData.FindAsync(id);
            if (nutritionFacts == null)
            {
                return NotFound();
            }
            return View(nutritionFacts);
        }

        // POST: NutritionFacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NutritionId,FoodName,CaloriesPerServing,CarbohydratesPerServing,ProteinPerServing,FatPerServing,PhosphorusPerServing,PotassiumPerServing,SodiumPerServing,Servings,Date")] NutritionFacts nutritionFacts)
        {
            if (id != nutritionFacts.NutritionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutritionFacts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutritionFactsExists(nutritionFacts.NutritionId))
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
            return View(nutritionFacts);
        }

        // GET: NutritionFacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NutritionData == null)
            {
                return NotFound();
            }

            var nutritionFacts = await _context.NutritionData
                .FirstOrDefaultAsync(m => m.NutritionId == id);
            if (nutritionFacts == null)
            {
                return NotFound();
            }

            return View(nutritionFacts);
        }

        // POST: NutritionFacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NutritionData == null)
            {
                return Problem("Entity set 'RecipeDBContext.NutritionData'  is null.");
            }
            var nutritionFacts = await _context.NutritionData.FindAsync(id);
            if (nutritionFacts != null)
            {
                _context.NutritionData.Remove(nutritionFacts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutritionFactsExists(int id)
        {
          return _context.NutritionData.Any(e => e.NutritionId == id);
        }
    }
}
