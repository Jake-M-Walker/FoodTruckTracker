using FoodTrucks.Data;
using FoodTrucks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Services
{
    public class TruckServices
    {
        private readonly string _userId;
        
        public TruckServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateTruck(TrucksCreate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Trucks.Add(new Trucks
                {
                    TruckName = model.TruckName,
                    UserId = _userId,
                    Owner = model.Owner,
                    Description = model.Description,
                    FoodType = model.FoodType
                });
                if(ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<TrucksListItem> GetTrucks()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Trucks
                    .Select(e =>
                    new TrucksListItem
                    {
                        TruckId = e.TruckId,
                        TruckName = e.TruckName,
                        Owner = e.Owner,
                        Description = e.Description
                    });
                return query.ToArray();
            }
        }

        public TrucksDetail GetTruckById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Trucks.Find(id);
                if(entity != null)
                {
                    return new TrucksDetail
                    {
                        TruckId = entity.TruckId,
                        TruckName = entity.TruckName,
                        UserId = entity.UserId,
                        Description = entity.Description,
                        FoodType = entity.FoodType,
                        UserName = entity.ApplicationUser.Email
                    };
                }
                return null;
            }
        }

        public bool DeleteTruckById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Trucks.Find(id);
                if(entity != null)
                {
                    ctx.Trucks.Remove(entity);
                    if(ctx.SaveChanges() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool EditTruck(TrucksEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Trucks.Find(model.TruckId);
                if(entity != null)
                {
                    entity.TruckName = model.TruckName;
                    entity.Owner = model.Owner;
                    entity.Description = model.Description;
                    entity.FoodType = model.FoodType;
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
