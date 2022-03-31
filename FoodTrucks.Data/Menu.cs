﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public decimal CostforTruck { get; set; }


        [Required]
        [ForeignKey(nameof(Trucks))]
        public int TruckId { get; set; }

        public virtual Trucks Truck { get; set; }


        public virtual ICollection<Locations> Locations { get; set; }

        


    }
}
