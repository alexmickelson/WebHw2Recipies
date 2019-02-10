using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoCore.Models;
using TodoCore.Services;

namespace TodoCore.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeService _recipeService;

        public HomeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _recipeService.GetAllRecipesAsync());
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

        [HttpGet]
        public IActionResult Form()
        {
            var recipe = new FormModel();
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(FormModel formModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            Recipe recipe = new Recipe();
            recipe.Name = formModel.Name;
            recipe.Description = formModel.Description;
            recipe.Ingredients = new List<Ingredient>();
            recipe.AddIngredient(new Ingredient(formModel.ing1,formModel.qty1 , formModel.meas1));
            recipe.AddIngredient(new Ingredient(formModel.ing2, formModel.qty2, formModel.meas2));

            _recipeService.AddRecipe(recipe);
            return RedirectToAction(nameof(Index));
        }
       

        [HttpGet]
        public IActionResult Delete()
        {
            _recipeService.DeleteAll();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RecipeDetails(int id)
        {
            var recipe = _recipeService.GetRecipe(id);
            return View(recipe);
        }

        
        public IActionResult AddIngredient(Ingredient ingredient)
        {
            _recipeService.GetRecipe(ingredient.parent).AddIngredient(ingredient);
            _recipeService.Update();

            return RedirectToAction(nameof(Index));
        }
    }
}
