using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FABS_DataAccess.Repository
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly FABSContext _context;

        public LocationRepository()
        {
            _context = new FABSContext();
        }

        public Location Get(PrimaryKey pk, int organisationId)
        {
            Location foundLocation;
            try
            {
                int id = GetPrimaryKeyValue(pk);
                //eager loading
                foundLocation = _context.Locations
                    //Warehouse
                .Include(w => w.Warehouses)
                .ThenInclude(a => a.Addresses)
                .ThenInclude(z => z.ZipcodeCountryCity)
                .ThenInclude(c => c.Countries)
                    //Person
                .Include(p => p.People)
                .ThenInclude(l => l.Login)
                    //Organisation
                .Include(o1 => o1.Organisations)
                .ThenInclude(o2 => o2.OrganisationPeople)
                    //Default
                .FirstOrDefault(x => x.Id == id);
            }
            
            catch
            {
                foundLocation = null;
            }

            return foundLocation;
        }


        public IEnumerable<Location> GetAll(int organisationId)
        {
            IEnumerable<Location> listLocation;
            try
            {
                listLocation = _context.Locations
                    //Warehouse
                .Include(w => w.Warehouses)
                    //Location
                .ThenInclude(a => a.Addresses)
                .ThenInclude(z => z.ZipcodeCountryCity)
                .ThenInclude(c => c.Countries)
                    //Person
                .Include(p => p.People)
                .ThenInclude(l => l.Login)
                    //Organisation
                .Include(o1 => o1.Organisations)
                .ThenInclude(o2 => o2.OrganisationPeople);
            }

            catch
            {
                listLocation = null;
            }

            return listLocation;
        }


        public int Create(Location l)
        {
            int insertId;
            try
            {
                var res = _context.Locations.Add(l);
                _context.SaveChanges();
                insertId = res.Entity.Id;
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                insertId = -1;
            }

            return insertId;
        }

        public bool Delete(PrimaryKey pk)
        {
            bool wasDeleted = false;

            try
            {
                int id = GetPrimaryKeyValue(pk);
                var l = _context.Locations.Find(id);
                var res = _context.Remove(l);
                _context.SaveChanges();
                wasDeleted = true;
            }

            catch
            {
                wasDeleted = false;
            }

            return wasDeleted;
        }



        public bool Update(PrimaryKey pk, Location l)
        {
            //throw new NotImplementedException();
            //TO DO: Get update to work in EF
            bool wasUpdated;

            try
            {
                int id = GetPrimaryKeyValue(pk);
                //Get the context entity form DB so we can change it
                var locationResultEntity = _context.Locations.Find(id);
                //Update the context entity with the date recieved from the update object
                    //Location
                locationResultEntity.PickLocation = l.PickLocation;
                locationResultEntity.Description = l.Description;
                locationResultEntity.Warehouses = l.Warehouses;
                locationResultEntity.People = l.People;
                locationResultEntity.Organisations = l.Organisations;

                _context.SaveChanges();
                wasUpdated = true;
            }

            catch
            {
                wasUpdated = false;
            }

            return wasUpdated;
        }

        private int GetPrimaryKeyValue(PrimaryKey pk) => (int) pk.KeyValues.First();

        public PrimaryKey FindPrimaryKey(Location t)
        {
            throw new NotImplementedException();
        }
    }
}
