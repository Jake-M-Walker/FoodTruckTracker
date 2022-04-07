using FoodTrucks.Data;
using FoodTrucks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Services
{
    public class LocationServices
    {
        private readonly string _userId;

        public LocationServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(new Locations
                {
                    LocationName = model.LocationName,
                    Address = model.Address,
                    TimeOpen = model.TimeOpen,
                    TimeClose = model.TimeClose,
                    IsHere = model.IsHere,
                    DateatLocation = model.DateatLocation
                });

                if(ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    .Select(e =>
                    new LocationListItem
                    {
                        LocationId = e.LocationId,
                        LocationName = e.LocationName,
                        Address = e.Address,
                        TimeOpen = e.TimeOpen,
                        TimeClose = e.TimeClose,
                        IsHere = e.IsHere,
                        DateatLocation = e.DateatLocation
                    });
                return query.ToArray();
            }
        }

        public LocationDetail GetLocationById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Find(id);
                if (entity != null)
                {
                    return new LocationDetail
                    {
                        LocationId = entity.LocationId,
                        LocationName = entity.LocationName,
                        Address = entity.Address,
                        TimeOpen = entity.TimeOpen,
                        TimeClose = entity.TimeClose,
                        IsHere = entity.IsHere,
                        DateatLocation = entity.DateatLocation
                    };
                }
                return null;
            }

        }

        public bool DeleteLocationById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Find(id);
                if(entity != null)
                {
                    ctx.Locations.Remove(entity);
                    if(ctx.SaveChanges() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EditLocation (LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Find(model.LocationId);
                if(entity != null)
                {
                    entity.LocationName = entity.LocationName;
                    entity.Address = entity.Address;
                    entity.TimeOpen = entity.TimeOpen;
                    entity.TimeClose = entity.TimeClose;
                    entity.IsHere = entity.IsHere;
                    entity.DateatLocation = entity.DateatLocation;
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
