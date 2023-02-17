using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Renipe.DataContext;
using Renipe.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.WebSockets;
using Microsoft.Build.Construction;

namespace Renipe.Controllers
{
    public class NutritionFactsController : Controller
    {
        private readonly RenipeDBContext _context;

        HttpClient client = new();

        static FdcResults jsData = new();

        static NutritionFacts nutritionItem = new();

        public NutritionFactsController(RenipeDBContext context)
        {
            _context = context;
        }

        // GET: NutritionFacts
        public async Task<IActionResult> Index()
        {
              return View(await _context.NutritionData.OrderByDescending(i => i.Date).ToListAsync());
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> Results(Search model)
        {
            if(client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://api.nal.usda.gov/fdc/v1/foods/search");
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress.ToString() + "?query=" + model.SearchString + "&api_key=" + "beRFFWSIsr5S5dntcc8JS1tFscBHd5mtbkonR5Ps");
            if (response.IsSuccessStatusCode)
            {
                var jstr = await response.Content.ReadAsStringAsync();
                jsData = JsonConvert.DeserializeObject<FdcResults>(jstr);

                return View(jsData);
            }
            else
            {
                return Content("No Food Items Found");
            }

        }

        // GET: NutritionFacts/NutritionDetails/5
        public async Task<IActionResult> NutritionDetails(int? id)
        {
            if (id == null || jsData.foods == null)
            {
                return NotFound();
            }

            var nutritionFacts = jsData.foods.FirstOrDefault(f => f.fdcId == id).ToModel();
            if (nutritionFacts == null)
            {
                return NotFound();
            }

            nutritionItem = nutritionFacts;
            return View(nutritionFacts);
        }

        // GET: NutritionFacts/NutritionDetails/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NutritionData == null)
            {
                return NotFound();
            }

            var nutritionFacts = _context.NutritionData.FirstOrDefault(f => f.MealId == id);
            if (nutritionFacts == null)
            {
                return NotFound();
            }

            return View(nutritionFacts);
        }

        // GET: NutritionFacts/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(nutritionItem.ToMeal());
        }

        // POST: NutritionFacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealId,FoodName,CaloriesPerServing,CarbohydratesPerServing,ProteinPerServing,FatPerServing,PhosphorusPerServing,PotassiumPerServing,SodiumPerServing,Servings,Date")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
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
        public async Task<IActionResult> Edit(int id, [Bind("MealId,FoodName,CaloriesPerServing,CarbohydratesPerServing,ProteinPerServing,FatPerServing,PhosphorusPerServing,PotassiumPerServing,SodiumPerServing,Servings,Date")] Meal meal)
        {
            if (id != meal.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutritionFactsExists(meal.MealId))
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
            return View(meal);
        }

        // GET: NutritionFacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NutritionData == null)
            {
                return NotFound();
            }

            var nutritionFacts = await _context.NutritionData
                .FirstOrDefaultAsync(m => m.MealId == id);
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
                return Problem("Entity set 'RenipeDBContext.NutritionData'  is null.");
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
          return _context.NutritionData.Any(e => e.MealId == id);
        }
    }
}
