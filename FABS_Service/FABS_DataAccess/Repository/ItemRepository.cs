using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FABS_DataAccess.Repository
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly FABSContext _context;

        public ItemRepository(string nameOfConnectionString)
        {
            _context = new FABSContext(nameOfConnectionString);
        }

        public Item Get(int id, int organisationId)
        {
            Item foundItem;
            try
            {
                //Eager loading
                foundItem = _context.Items
                        //Organisation
                    .Include(o => o.Organisations)
                        //Status
                    .Include(s => s.Statuses)
                        //Location
                    .Include(l => l.Locations)
                    .ThenInclude(w => w.Warehouses)
                    .ThenInclude(a => a.Addresses)
                    .ThenInclude(z => z.ZipcodeCountryCity)
                    .ThenInclude(c => c.Countries)
                        //Items
                    .Include(i => i.ItemTypes)
                    .ThenInclude(k => k.KayakType)
                        //Default
                    .FirstOrDefault(x => x.Id == id);
            }

            catch
            {
                foundItem = null;
            }

            return foundItem;
        }

        public IEnumerable<Item> GetAll(int organisationId)
        {
            IEnumerable<Item> listItem;
            try
            {
                listItem = _context.Items

                    //Organisation
                    .Include(o => o.Organisations)
                    //Status
                    .Include(s => s.Statuses)
                    //Location
                    .Include(l => l.Locations)
                    .ThenInclude(w => w.Warehouses)
                    .ThenInclude(a => a.Addresses)
                    .ThenInclude(z => z.ZipcodeCountryCity)
                    .ThenInclude(c => c.Countries)
                    //Items
                    .Include(i => i.ItemTypes)
                    .ThenInclude(k => k.KayakType);
            }

            catch
            {
                listItem = null;
            }

            return listItem;
        }

        public IEnumerable<Item> GetAll(DateTime startDate, DateTime endDate, int organisationId)
        {
            throw new NotImplementedException();
        }

        public int Create(Item i)
        {
            int insertId;
            try
            {
                var res = _context.Items.Add(i);
                _context.SaveChanges();
                insertId = res.Entity.Id;
            }

            catch (Exception e)
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
                var i = _context.Items.Find(id);
                var res = _context.Remove(i);
                _context.SaveChanges();
                wasDeleted = true;
            }

            catch
            {
                wasDeleted = false;
            }

            return wasDeleted;
        }

        public bool Update(int id, Item i)
        {
            //throw new NotImplementedException();
            //TO DO: Get update to work in EF
            bool wasUpdated;

            try
            {
                //Get the context entity form DB so we can change it
                var itemResultEntity = _context.Items.Find(id);
                //Update the context entity with the date recieved from the update object
                //Item
                itemResultEntity.Organisations = i.Organisations;
                itemResultEntity.Statuses = i.Statuses;
                itemResultEntity.Locations = i.Locations;
                itemResultEntity.ItemTypes = i.ItemTypes;

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
