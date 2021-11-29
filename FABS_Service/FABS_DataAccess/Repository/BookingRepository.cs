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

        //WIP

        //private readonly FABSContext _context;
        private readonly string _connect = ConfigurationManager.ConnectionStrings["FABS_connectionstring"].ToString();

        //public BookingRepository()
        //{
        //    _context = new FABSContext();
        //}

        //public Booking Get(int id, int organitionId)
        //{
        //    Booking foundBooking;
        //    try
        //    {
        //        //eager loading
        //        foundBooking = _context.Bookings
        //            //Person
        //        .Include(p1 => p1.People)
        //            //Status
        //        .Include(s => s.Statuses)


        //        .FirstOrDefault(x => x.Id == id);
        //    }
        //    catch
        //    {
        //        foundBooking = null;
        //    }

        //    return foundBooking;
        //}

        //public IEnumerable<Booking> GetAll(int organisationId)
        //{
        //    IEnumerable<Booking> listBooking;

        //    try
        //    {
        //        listBooking = _context.Bookings
        //        //Person
        //        .Include(p1 => p1.People)
        //        //Status
        //        .Include(s => s.Statuses)
        //    }
        //    catch
        //    {
        //        listBooking = null;
        //    }

        //    return listBooking;
        //}





        //public int Create(Booking b)
        //{
        //    int insertedID;
        //    try
        //    {
        //        var res = _context.Bookings.Add(b);
        //        _context.SaveChanges();
        //        insertedID = res.Entity.Id;
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        insertedId = -1;
        //    }
        //}

        //public bool 


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
            //throw new NotImplementedException();
            IEnumerable<Booking> listBooking;

            try
            {
                listBooking = _context.Booking
                .Where(p => p.OrganisationPeople.Any(op => op.OrganisationsId == organisationId))
                .Include(a => a.Addresses)
                .ThenInclude(z => z.ZipcodeCountryCity)
                .ThenInclude(c => c.Countries)
                .Include(l => l.Login)
                .Include(op => op.OrganisationPeople)
                .ThenInclude(a => a.Organisations);


            }
            catch
            {
                listBooking = null;
            }
            return listBooking;
        }

        public bool Update(int id, Booking t)
        {
            throw new NotImplementedException();
        }
    }
}
