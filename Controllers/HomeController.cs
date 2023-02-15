using Fridgeopolis.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;
using System.Net.Http;

namespace Fridgeopolis.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index() {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RecipeInstruction(Recipe model)
        {

            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://api.spoonacular.com/");
            }
            //client.BaseAddress = new Uri("https://api.spoonacular.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("MyAPIKey", "36d0332aea3241798e916aa4cbd2a928");

            //HttpResponseMessage response = await client.GetAsync("https://api.spoonacular.com" + "/recipes/" + model.ID + "/information?apiKey=" + "5828cde1106e400b9469ae1a2f9732ee" + "&includeNutrition=true");
            HttpResponseMessage response = await client.GetAsync("https://api.spoonacular.com" + "/recipes/" + model.ID + "/analyzedInstructions?apiKey=" + "36d0332aea3241798e916aa4cbd2a928");
            //ShowResult(response);
            if (response.IsSuccessStatusCode)
            {
                var jstr = await response.Content.ReadAsStringAsync();
                //var recipeinfo = JsonConvert.DeserializeObject<RecipeData>(jstr);
                List<Instructions> oop = JsonConvert.DeserializeObject<List<Instructions>>(jstr);

                //var jstr2 = await response2.Content.ReadAsStringAsync();
                //RecipeData recipeinfo2 = JsonConvert.DeserializeObject<RecipeData>(jstr2);

                return PartialView(oop);
                //var jstr = await response.Content.ReadAsStringAsync();
                //RecipeData recipeInfo = JsonConvert.DeserializeObject<RecipeData>(jstr);
                //model.ID = recipeInfo.ID;
                //return View(recipeInfo);

            }
            else
            {
                return Content("No information found");
            }
        }
        [HttpGet]
        public async Task<IActionResult> RecipeSummary(Recipe model)
        {

            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://api.spoonacular.com/");
            }
            //client.BaseAddress = new Uri("https://api.spoonacular.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("MyAPIKey", "36d0332aea3241798e916aa4cbd2a928");

            //HttpResponseMessage response = await client.GetAsync("https://api.spoonacular.com" + "/recipes/" + model.ID + "/information?apiKey=" + "5828cde1106e400b9469ae1a2f9732ee" + "&includeNutrition=true");
            HttpResponseMessage response = await client.GetAsync("https://api.spoonacular.com" + "/recipes/" + model.ID + "/summary?apiKey=" + "36d0332aea3241798e916aa4cbd2a928");
            //ShowResult(response);
            if (response.IsSuccessStatusCode)
            {
                var jstr = await response.Content.ReadAsStringAsync();
                RecipeData recipeinfo = JsonConvert.DeserializeObject<RecipeData>(jstr);

                //var jstr2 = await response2.Content.ReadAsStringAsync();
                //RecipeData recipeinfo2 = JsonConvert.DeserializeObject<RecipeData>(jstr2);

                return PartialView(recipeinfo);
                //var jstr = await response.Content.ReadAsStringAsync();
                //RecipeData recipeInfo = JsonConvert.DeserializeObject<RecipeData>(jstr);
                //model.ID = recipeInfo.ID;
                //return View(recipeInfo);

            }
            else
            {
                return Content("No information found");
            }
        }
        [HttpGet]
        public async Task<IActionResult> RecipeInfo(Recipe model)
        {

            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://api.spoonacular.com/");
            }
            //client.BaseAddress = new Uri("https://api.spoonacular.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("MyAPIKey", "36d0332aea3241798e916aa4cbd2a928");

            HttpResponseMessage response = await client.GetAsync("https://api.spoonacular.com" + "/recipes/" + model.ID + "/information?apiKey=" + "36d0332aea3241798e916aa4cbd2a928" + "&includeNutrition=true");
            //HttpResponseMessage response2 = await client.GetAsync("https://api.spoonacular.com" + "/recipes/" + model.ID + "/summary?apiKey=" + "5828cde1106e400b9469ae1a2f9732ee");
            //ShowResult(response);
            if (response.IsSuccessStatusCode)
            {
                var jstr = await response.Content.ReadAsStringAsync();
                RecipeData recipeinfo = JsonConvert.DeserializeObject<RecipeData>(jstr);

                //var jstr2 = await response2.Content.ReadAsStringAsync();
                //RecipeData recipeinfo2 = JsonConvert.DeserializeObject<RecipeData>(jstr2);

                return View(recipeinfo);
                //var jstr = await response.Content.ReadAsStringAsync();
                //RecipeData recipeInfo = JsonConvert.DeserializeObject<RecipeData>(jstr);
                //model.ID = recipeInfo.ID;
                //return View(recipeInfo);

            }
            else
            {
                return Content("No information found");
            }
        }

        [HttpGet("ingredients")]
        public async Task<IActionResult> Details(Ingredient model)
        {

            string str = "";

            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://api.spoonacular.com/");
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("MyAPIKey", "36d0332aea3241798e916aa4cbd2a928");
            HttpResponseMessage response = await client.GetAsync("https://api.spoonacular.com" + "/recipes/findByIngredients?ingredients=" + model.ingredients + "&number=" + 10 + "&limitLicense=true&ranking=1&ignorePantry=false&apiKey=" + "36d0332aea3241798e916aa4cbd2a928");
            //ShowResult(response);
            if (response.IsSuccessStatusCode)
            {
                    var jstr = await response.Content.ReadAsStringAsync();
                    var jsData = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(jstr);
                
                    
                return View(jsData);

            }
            else
            {
                return Content("No recipes found!");
            }


            //string jsonData = @"{'FirstName': 'John', 'LastName': 'Smith'}";
            //var details = JObject.Parse(jsonData);
            //Console.WriteLine(string.Concat("Hi ", details["FirstName"], " " + details["LastName"]));
            return View();
        }
        [HttpPost]
        public IActionResult Save(Recipe model)
        {
            //PropertyModel data = new PropertyModel()
            //{
            //    ID = model.ID,
            //    Title = model.Title,
            //    SourceUrl = model.SourceUrl
            //};
            //TempData["PopupMessages"] = JsonConvert.SerializeObject(_popupMessages);
            TempData["mydata"] = model.ID;
            TempData["mydata2"] = model.Title;
            TempData["mydata3"] = model.SourceUrl;
            return RedirectToAction("Create", "PropertyModels");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}