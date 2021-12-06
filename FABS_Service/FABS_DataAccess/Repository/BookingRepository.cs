using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Transactions;
using FABS_DataAccess.BusinessLogic;

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

        /// <summary>
        /// This method Creates booking in the database, if data is correct and there is no overlap between bookings and their items
        /// </summary>
        /// <param name="booking">The incoming booking with items</param>
        /// <returns>Number of rows affected, or 0 if no rows have been written in DB (not successfull)</returns>
        public int Create(Booking booking)
        {

            bool allSuccessfull = false;
            int numberOfRowsInserted = 0;

            decimal insertedBookingId = -1;

            //Validate booking has item
            //TODO: Make exception.
            if (booking.BookingLines.Count == 0)
            {
                return numberOfRowsInserted;
            }

            //validate Date Range
            //TODO: Make exception.
            if (!BookingLogic.DateRangeValidator(booking.StartDatetime, booking.EndDatetime))
            {
                return numberOfRowsInserted;
            }

            //Validate Overlapping
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (BookingLogic.HasOverlap(conn, booking))
                {
                    return numberOfRowsInserted;
                }
            
            }


            // Prepare command for inserting booking
            string bookingQuery = "INSERT INTO bookings(start_datetime, end_datetime, people_id, statuses_id) " +
                                 "VALUES(@StartDate{}Time, @EndDateTime, @PersonId, @StatusId) SELECT scope_identity()";
            // Prepare command for inserting bookinglines
            //TODO: Validate item availability in SQL string
            string bookingLineQuery = "INSERT INTO booking_line(bookings_id, items_id)" +
                                      "VALUES(@BookingId, @ItemId)";

            using SqlCommand insertBookingCommand = new SqlCommand(bookingQuery, conn);

            insertBookingCommand.Parameters.AddWithValue("StartDateTime", booking.StartDatetime);
            insertBookingCommand.Parameters.AddWithValue("EndDateTime", booking.EndDatetime);
            insertBookingCommand.Parameters.AddWithValue("PersonId", booking.PeopleId);
            insertBookingCommand.Parameters.AddWithValue("StatusId", booking.StatusesId);



            insertedBookingId = (decimal)insertBookingCommand.ExecuteScalar();
            //TODO Try catch
            numberOfRowsInserted++;
            allSuccessfull = true;



            foreach (BookingLine bookingLine in booking.BookingLines)
            {
                using SqlCommand createBookingLineCommand = new SqlCommand(bookingLineQuery, conn);


                createBookingLineCommand.Parameters.AddWithValue("BookingId", insertedBookingId);
                createBookingLineCommand.Parameters.AddWithValue("ItemId", bookingLine.ItemsId);
                try
                {
                    //TODO Validate
                    numberOfRowsInserted += createBookingLineCommand.ExecuteNonQuery();
                    //numberOfRowsInserted++;
                    allSuccessfull = true;
                }
                catch (Exception ex)
                {
                    var res = ex;
                    allSuccessfull = false;
                    break;
                }
            }
            if (allSuccessfull)
            {
                ts.Complete();

            }
            else
            {
                numberOfRowsInserted = 0;
            }
        }


            return numberOfRowsInserted;
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
            string query = "SELECT bookings.id AS \"booking_id\", bookings.start_datetime, bookings.end_datetime, people.id AS \"people_id\", " +
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
        catch (Exception e)
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
