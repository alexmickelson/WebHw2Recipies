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

        public async Task<Recipe[]> GetAllRecipesAsync()
        {
            return await _applicationDbContext.Recipes.ToArrayAsync();
        }
    }
}
