using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class MenuListItem
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal CostforTruck { get; set; }

        public int TruckId { get; set; }

        public string TruckName { get; set; }
    }
}
