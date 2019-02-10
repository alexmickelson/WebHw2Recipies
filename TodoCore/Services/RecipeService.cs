using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Data;
using TodoCore.Models;

namespace TodoCore.Services
{
    public class RecipeService : IRecipeService
    {
        private ApplicationDbContext _applicationDbContext;

        public RecipeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public void AddRecipe(Recipe recipe)
        {
            _applicationDbContext.Recipes.Add(recipe);
            _applicationDbContext.SaveChanges();
        }

        public async void DeleteAll()
        {
            _applicationDbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Ingredient");
            _applicationDbContext.Recipes.RemoveRange(_applicationDbContext.Recipes);

            _applicationDbContext.SaveChanges();
        }



        public async Task<Recipe[]> GetAllRecipesAsync()
        {
            return await _applicationDbContext.Recipes
                .Include(i => i.Ingredients)
                .ToArrayAsync();
        }

        public void Update()
        {
            _applicationDbContext.SaveChanges();
        }

        
        public Recipe GetRecipe(int id)
        {
            return _applicationDbContext.Recipes.Include(r => r.Ingredients).Where(i => i.Id == id).First();
        }

        
    }
}
