using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCore.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public void AddIngredient(Ingredient ingredient)
        {
            if(ingredient.Qty <= 0)
            {
                ingredient.Qty = 1;
            }
            ingredient.parent = Id;
            Ingredients.Add(ingredient);
        }
    }
}
