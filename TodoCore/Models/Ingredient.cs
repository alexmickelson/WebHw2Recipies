using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCore.Models
{
    public class Ingredient
    {
        public Ingredient() { }
        public Ingredient(int par) { parent = par; }
        public Ingredient(string name)
        {
            Name = name;
        }
        public Ingredient(string name, int qty, string meas)
        {
            Name = name;
            Measure = meas;
            if (qty <= 0)
            {
                qty = 1;
            }
            Qty = qty;
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measure { get; set; }
        public int Qty { get; set; }
        public int parent { get; set; }
    }
}


