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
                    ItemId = model.MenuItem.ItemId,
                    NumberBought = model.NumberBought,
                    TotalCost = model.MenuItem.ItemPrice * model.NumberBought
                });

                if(ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public TransactionsDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Find(id);
                if(entity != null)
                {
                    return new TransactionsDetail
                    {
                        TransactionId = entity.TransactionId,
                        UserId = _userId,
                        TruckId = entity.TruckId,
                        ItemId = entity.ItemId,
                        TotalCost = entity.MenuItem.ItemPrice * entity.NumberBought,
                        TransactionDate = entity.TransactionDate
                    };
                }
                return null;
            }
        }

        public bool DeleteTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Find(id);
                if(entity != null)
                {
                    ctx.Transactions.Remove(entity);
                    if(ctx.SaveChanges() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool EditTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Find(model.TransactionId);
                if(entity != null)
                {
                    entity.TransactionDate = DateTimeOffset.Now;
                    entity.UserId = _userId;
                    entity.TruckId = model.TruckId;
                    entity.ItemId = model.ItemId;
                    entity.NumberBought = model.NumberBought;
                    entity.TotalCost = model.NumberBought * model.MenuItem.ItemPrice;
                    if(ctx.SaveChanges() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
