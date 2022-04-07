using FoodTrucks.Data;
using FoodTrucks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Services
{
    public class TransactionServices
    {
        private readonly string _userId;

        public TransactionServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(new Transactions
                {
                    TransactionDate = DateTimeOffset.Now,
                    UserId = _userId,
                    TruckId = model.Truck.TruckId,
                    ItemId = model.MenuItem.ItemId
                });

                if(ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
