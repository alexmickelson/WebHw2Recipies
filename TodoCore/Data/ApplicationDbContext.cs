using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoCore.Models;

namespace TodoCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RecipeIngredient>().HasKey(bc => new { bc.RecipeId, bc.IngredientId });
            builder.Entity<RecipeIngredient>()
                .HasOne(RI => RI.Recipe)
                .WithMany(b => b.RecipeIngredients)
                .HasForeignKey(RI => RI.RecipeId);
            builder.Entity<RecipeIngredient>()
                .HasOne(RI => RI.Ingredient)
                .WithMany(I => I.RecipeIngredients)
                .HasForeignKey(RI => RI.IngredientId);
        }
    }
}
