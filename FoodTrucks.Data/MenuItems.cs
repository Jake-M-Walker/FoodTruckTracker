using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class MenuItems
    {
        [Key]
        [Required]
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public decimal CostforTruck { get; set; }


        [ForeignKey(nameof(Trucks))]
        public int TruckId { get; set; }

        public virtual Trucks Trucks { get; set; }


        

        


    }
}
