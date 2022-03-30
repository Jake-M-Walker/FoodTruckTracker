using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class Menu
    {
        [Key]
        [Required]
        public int MenuId { get; set; }

        [Required]
        public string MainDish1 { get; set; }

        public string MainDish2 { get; set; }

        [Required]
        public string SideDish1 { get; set; }

        public string SideDish2 { get; set; }

        [Required]
        public string Dessert1 { get; set; }

        public string Dessert2 { get; set; }

        public string CustomDrink1 { get; set; }

        public string CustomDrink2 { get; set; }

        public string BottleDrinks { get; set; }
    }
}
