using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Data.SqlClient;

namespace FABS_DataAccess.Repository
{
    public class BookingRepository : IRepository<Booking>
    {

        //WIP

        //private readonly FABSContext _context;
        //private readonly string _connect = ConfigurationManager.ConnectionStrings["FABS_connectionstring"].ToString();
        private string _connectionString;

        public BookingRepository()
        {
            Initialize();
        }

        private void Initialize()
        {
            string physicalPath = "";
            string appSettingsString = @"FABS_API_Service\appsettings.json";
            string folderUpString = @"";
            // Loops to search back in folders to be able to find appsettings.
            // TODO: find a better solution than just looping 10 times
            for (int i = 0; i < 10; i++)
            {
                physicalPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), folderUpString));
                physicalPath += appSettingsString;
                if (physicalPath.Contains(@"FABS_Service\FABS_API_Service\appsettings.json"))
                {
                    break;
                }
                folderUpString += @"..\";
            }

            IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(physicalPath)
                .Build();
            _connectionString = Configuration.GetConnectionString("FABS_connectionstring");
        }



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
            //throw new NotImplementedException();
            Booking booking = new Booking();
            try
            {
                string query ="SELECT bookings.id AS \"booking_id\", bookings.start_datetime, bookings.end_datetime, people.id AS \"people_id\", " +
                    "bookings.statuses_id AS \"booking_statuses_id\", booking_line.items_id FROM booking_line " +
                    "INNER JOIN bookings ON booking_line.bookings_id = bookings.id " +
                    "INNER JOIN people ON bookings.people_id = people.id " +
                    "INNER JOIN items ON booking_line.items_id = items.id " +
                    $"where bookings_id = {id}";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(query, conn))
                {
                    if (conn != null)
                    {
                        conn.Open();
                        SqlDataReader bookingReader = readCommand.ExecuteReader();
                        booking = GetBookingObject(bookingReader);
                    }
                }
            }
            catch(Exception e)
            {
                booking = null;
            }
            return booking;
        }

        public IEnumerable<Booking> GetAll(int organisationId)
        {
            //throw new NotImplementedException();
            IEnumerable<Booking> listBooking = null;

            try
            {
                string query = "SELECT bookings.id AS \"booking_id\", bookings.start_datetime, bookings.end_datetime, people.id AS \"people_id\", " +
                    "bookings.statuses_id AS \"booking_statuses_id\", booking_line.items_id FROM booking_line " +
                    "INNER JOIN bookings ON booking_line.bookings_id = bookings.id " +
                    "INNER JOIN people ON bookings.people_id = people.id " +
                    "INNER JOIN items ON booking_line.items_id = items.id " +
                    "ORDER BY booking_id ASC";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(query, conn))
                {
                    if (conn != null)
                    {
                        conn.Open();
                        SqlDataReader bookingReader = readCommand.ExecuteReader();
                        listBooking = GetBookingObjects(bookingReader);
                    }
                }
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

        private IEnumerable<Booking> GetBookingObjects(SqlDataReader bookingReader)
        {
            //throw new NotImplementedException();

            List<Booking> foundBookings = new List<Booking>();
            Booking tempBooking = null;
            int tempBookingId; DateTime tempStartTime; DateTime tempEndTime; int tempPeopleId; int tempStatusId; int tempItemId;

            while (bookingReader.Read())
            {
                tempBookingId = bookingReader.GetInt32(bookingReader.GetOrdinal("booking_id"));
                tempStartTime = bookingReader.GetDateTime(bookingReader.GetOrdinal("start_datetime"));
                tempEndTime = bookingReader.GetDateTime(bookingReader.GetOrdinal("end_datetime"));
                tempPeopleId = bookingReader.GetInt32(bookingReader.GetOrdinal("people_id"));
                tempStatusId = bookingReader.GetInt32(bookingReader.GetOrdinal("booking_statuses_id"));
                tempItemId = bookingReader.GetInt32(bookingReader.GetOrdinal("items_id"));
                
                var foundBookingIds = foundBookings.Select(fb => fb.Id);
                if (!foundBookingIds.Contains(tempBookingId))
                {
                    tempBooking = new Booking(tempBookingId, tempStartTime, tempEndTime, tempPeopleId, tempStatusId);
                    foundBookings.Add(tempBooking);
                }
                    tempBooking.BookingLines.Add(new BookingLine(tempBookingId, tempItemId));
                
            }   
            
            return foundBookings;
        }

        private Booking GetBookingObject(SqlDataReader bookingReader)
        {
            Booking tempBooking = null;
            int tempBookingId; DateTime tempStartTime; DateTime tempEndTime; int tempPeopleId; int tempStatusId; int tempItemId;

            while (bookingReader.Read())
            {
                tempBookingId = bookingReader.GetInt32(bookingReader.GetOrdinal("booking_id"));
                tempStartTime = bookingReader.GetDateTime(bookingReader.GetOrdinal("start_datetime"));
                tempEndTime = bookingReader.GetDateTime(bookingReader.GetOrdinal("end_datetime"));
                tempPeopleId = bookingReader.GetInt32(bookingReader.GetOrdinal("people_id"));
                tempStatusId = bookingReader.GetInt32(bookingReader.GetOrdinal("booking_statuses_id"));
                tempItemId = bookingReader.GetInt32(bookingReader.GetOrdinal("items_id"));
                
                if (tempBooking == null)
                {
                    tempBooking = new Booking(tempBookingId, tempStartTime, tempEndTime, tempPeopleId, tempStatusId);
                }
                    tempBooking.BookingLines.Add(new BookingLine(tempBookingId, tempItemId));
                
            }
            return tempBooking;
        }
    }
}
