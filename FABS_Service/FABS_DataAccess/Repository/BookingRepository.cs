using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FABS_DataAccess.Repository
{
    public class BookingRepository : IRepository<Booking>
    {
        public int Create(Booking t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Booking Get(int id, int organisationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll(int organisationId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Booking t)
        {
            throw new NotImplementedException();
        }
    }
}
