using FoodTrucks.Data;
using FoodTrucks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Services
{
    public class MenuItemServices
    {
        private readonly string _userId;

        public MenuItemServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateMenuItem (MenuItemCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MenuItems.Add(new MenuItem
                {
                    ItemName = model.ItemName,
                    ItemDescription = model.ItemDescription,
                    ItemPrice = model.ItemPrice,
                    CostforTruck = model.CostforTruck,
                    TruckId = model.TruckId
                });
                if(ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<MenuListItem> GetMenuItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MenuItems
                    .Select(e =>
                    new MenuListItem
                    {
                        ItemId = e.ItemId,
                        ItemName = e.ItemName,
                        ItemDescription = e.ItemDescription,
                        ItemPrice = e.ItemPrice,
                        CostforTruck = e.CostforTruck,
                        TruckId = e.Truck.TruckId,
                        TruckName = e.Truck.TruckName
                    });
                return query.ToArray();
            }
        }

        public MenuItemDetail GetMenuItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MenuItems.Find(id);
                if(entity != null)
                {
                    return new MenuItemDetail
                    {
                        ItemId = entity.ItemId,
                        ItemName = entity.ItemName,
                        ItemDescription = entity.ItemDescription,
                        ItemPrice = entity.ItemPrice,
                        CostforTruck = entity.CostforTruck,
                        TruckId = entity.Truck.TruckId,
                        TruckName = entity.Truck.TruckName
                    };
                }
                return null;
            }
        }

        public bool DeleteMenuItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MenuItems.Find(id);
                if(entity != null)
                {
                    ctx.MenuItems.Remove(entity);
                    if(ctx.SaveChanges() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool EditMenuItem (MenuItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MenuItems.Find(model.ItemId);
                if(entity != null)
                {
                    entity.ItemName = model.ItemName;
                    entity.ItemDescription = model.ItemDescription;
                    entity.ItemPrice = model.ItemPrice;
                    entity.CostforTruck = model.CostforTruck;
                    entity.TruckId = model.TruckId;
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
