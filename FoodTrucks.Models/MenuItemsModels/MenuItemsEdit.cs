using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class MenuItemEdit
    {
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public decimal CostforTruck { get; set; }

        [Required]
        public int TruckId { get; set; }

        [Required]
        public string TruckName { get; set; }


    }
}
