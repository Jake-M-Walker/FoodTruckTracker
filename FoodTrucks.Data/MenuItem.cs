using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal CostforTruck { get; set; }


        [ForeignKey("Truck")]
        public int TruckId { get; set; }

        public virtual Truck Truck { get; set; }


        

        


    }
}
