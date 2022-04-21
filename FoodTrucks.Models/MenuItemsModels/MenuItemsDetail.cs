using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class MenuItemDetail
    {
        [Display(Name = "Item Id")]
        public int ItemId { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ItemPrice { get; set; }

        [Display(Name = "Cost for Truck")]
        public decimal CostforTruck { get; set; }

        [Display(Name = "Truck Id")]
        public int TruckId { get; set; }

        [Display(Name = "Truck Name")]
        public string TruckName { get; set; }
    }
}
