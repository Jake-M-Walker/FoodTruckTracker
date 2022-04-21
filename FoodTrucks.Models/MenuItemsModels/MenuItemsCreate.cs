using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class MenuItemCreate
    {
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ItemPrice { get; set; }

        [Display(Name = "Cost for Truck")]
        public decimal CostforTruck { get; set; }

        [Display(Name = "Truck")]
        public int TruckId { get; set; }

    }
}
