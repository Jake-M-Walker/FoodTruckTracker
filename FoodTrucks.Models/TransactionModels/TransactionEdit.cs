﻿using FoodTrucks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class TransactionEdit
    {
        public int TransactionId { get; set; }


        [Required]
        public DateTimeOffset TransactionDate { get; set; }

        [Required]
        public string UserId { get; set; }

        
        [ForeignKey(nameof(Trucks))]
        public int TruckId { get; set; }

        public virtual Trucks Truck { get; set; }

        [ForeignKey(nameof(MenuItems))]
        public int ItemId { get; set; }

        public virtual MenuItems MenuItem { get; set; }

        public int NumberBought { get; set; }

        public decimal TotalCost { get; set; }



    }
}