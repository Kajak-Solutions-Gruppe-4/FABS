using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FABS_DataAccess.Repository
{
    public class WarehouseRepository : IRepository<Warehouse>
    {
        public IEnumerable<Warehouse> GetAll(int organisationId)
        {
            throw new NotImplementedException();
        }

        public Warehouse Get(int id, int organisationId)
        {
            throw new NotImplementedException();
        }

        public int Create(Warehouse t)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Warehouse t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
