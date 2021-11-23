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

        public bool Delete(PrimaryKey pk)
        {
            throw new NotImplementedException();
        }

        public PrimaryKey FindPrimaryKey(Booking t)
        {
            throw new NotImplementedException();
        }

        public Booking Get(PrimaryKey pk, int organisationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll(int organisationId)
        {
            throw new NotImplementedException();
        }

        public bool Update(PrimaryKey pk, Booking t)
        {
            throw new NotImplementedException();
        }
    }
}
