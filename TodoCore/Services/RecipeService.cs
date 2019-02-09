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
            _applicationDbContext.SaveChangesAsync();
        }

        public async void DeleteAll()
        {
            _applicationDbContext.Ingredients.RemoveRange(_applicationDbContext.Ingredients);
            _applicationDbContext.Recipes.RemoveRange(_applicationDbContext.Recipes);
            _applicationDbContext.SaveChanges();
        }

        

        public async Task<Recipe[]> GetAllRecipesAsync()
        {
            return await _applicationDbContext.Recipes.ToArrayAsync();
        }


        public Ingredient[] GetIngredients(Recipe recipe)
        {
            return _applicationDbContext.Ingredients.Where(i => i.RecipeIngredients.Any(ri => ri.RecipeId == recipe.Id)).ToArray();
            
        }

        public Recipe GetRecipe(Guid recipeId)
        {
            return _applicationDbContext.Recipes.First(r => r.Id == recipeId);
        }
    }
}
