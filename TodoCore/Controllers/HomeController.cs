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

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(Recipe recipe)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _recipeService.
        }
    }
}
