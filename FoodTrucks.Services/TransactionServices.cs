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
                ctx.Transactions.Add(new Transaction
                {
                    TransactionDate = DateTimeOffset.Now,
                    UserId = _userId,
                    TruckId = model.TruckId,
                    ItemId = model.ItemId,
                    NumberBought = model.NumberBought,
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
                        TruckName = entity.Truck.TruckName,
                        ItemId = entity.ItemId,
                        ItemName = entity.MenuItem.ItemName,
                        NumberBought = entity.NumberBought,
                        TotalCost = entity.TotalCost,
                        TransactionDate = entity.TransactionDate,
                        UserName = entity.ApplicationUser.Email,
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
                    if(ctx.SaveChanges() > 1)
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
                    if(ctx.SaveChanges() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public IEnumerable<TransactionsListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transactions
                    .Select(e =>
                    new TransactionsListItem
                    {
                        TransactionId = e.TransactionId,
                        TransactionDate = e.TransactionDate,
                        UserId = _userId,
                        UserName = e.ApplicationUser.Email,
                        TruckId = e.Truck.TruckId,
                        TruckName = e.Truck.TruckName,
                        ItemId = e.MenuItem.ItemId,
                        ItemName = e.MenuItem.ItemName,

                    });
                return query.ToArray();
            }
        }

    }
}
