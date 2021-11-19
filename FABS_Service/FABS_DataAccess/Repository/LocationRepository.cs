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
            throw new NotImplementedException();
        }

        public Location Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Location t)
        {
            throw new NotImplementedException();
        }
    }

}
