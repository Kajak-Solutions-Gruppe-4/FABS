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

        public LocationRepository(string nameOfConnectionString)
        {
            _context = new FABSContext(nameOfConnectionString);
        }

        public Location Get(int id, int organisationId)
        {
            Location foundLocation;
            try
            {
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
                .Include(o => o.Organisations)
                .ThenInclude(o=> o.Addresses)
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
                .ThenInclude(o2 => o2.OrganisationPeople)
                .Where(op => op.OrganisationsId == organisationId);
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

        public bool Delete(int id)
        {
            bool wasDeleted = false;

            try
            {
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



        public bool Update(int id, Location l)
        {
            //throw new NotImplementedException();
            //TO DO: Get update to work in EF
            bool wasUpdated;

            try
            {
                //Get the context entity form DB so we can change it
                var locationResultEntity = _context.Locations.Find(id);
                //Update the context entity with the date recieved from the update object
                    //Location
                locationResultEntity.PickLocation = l.PickLocation;
                locationResultEntity.Description = l.Description;
                locationResultEntity.Warehouses = l.Warehouses;
                locationResultEntity.People = l.People;
                locationResultEntity.Organisations = l.Organisations;
                    //Other
                locationResultEntity.Items = l.Items;

                _context.SaveChanges();
                wasUpdated = true;
            }

            catch
            {
                wasUpdated = false;
            }

            return wasUpdated;
        }
    }
}
