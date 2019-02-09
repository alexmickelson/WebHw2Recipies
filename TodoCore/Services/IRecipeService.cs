using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Models;

namespace TodoCore.Services
{
    public interface IRecipeService
    {
        Task<Recipe[]> GetAllRecipesAsync();
        void AddRecipe(Recipe recipe);
        void DeleteAll();
        Ingredient[] GetIngredients(Recipe recipe);
        Recipe GetRecipe(Guid recipeId);
    }
}
