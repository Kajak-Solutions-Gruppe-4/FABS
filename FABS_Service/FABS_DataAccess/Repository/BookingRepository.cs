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

        // This create booking works!
        

        public int Create(Booking booking)
        {

            int numberOfRowsInserted = 0;

            decimal insertedBookingId = -1;
            string connectionString = _connectionString;

            // Prepare command for inserting booking
            string bookingQuery = "INSERT INTO bookings(start_datetime, end_datetime, people_id, statuses_id) " +
                                 "VALUES(@StartDateTime, @EndDateTime, @PersonId, @StatusId) SELECT scope_identity()";
            // Prepare command for inserting bookinglines
            string bookingLineQuery = "INSERT INTO booking_line(bookings_id, items_id)" +
                                      "VALUES(@BookingId, @ItemId)";

            // Get connection and run command
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand insertBookingCommand = new SqlCommand(bookingQuery, conn))
            {

                insertBookingCommand.Parameters.AddWithValue("StartDateTime", booking.StartDatetime);
                insertBookingCommand.Parameters.AddWithValue("EndDateTime", booking.EndDatetime);
                insertBookingCommand.Parameters.AddWithValue("PersonId", booking.PeopleId);
                insertBookingCommand.Parameters.AddWithValue("StatusId", booking.StatusesId);

                if (conn != null)
                {
                    conn.Open();

                    insertedBookingId = (decimal)insertBookingCommand.ExecuteScalar();
                    numberOfRowsInserted++;
                }


                foreach (BookingLine bookingLine in booking.BookingLines)
                {
                    using (SqlCommand createBookingLineCommand = new SqlCommand(bookingLineQuery, conn))
                    {

                        //createBookingLineCommand.CommandText = bookingLineQuery;
                        createBookingLineCommand.Parameters.AddWithValue("BookingId", insertedBookingId);
                        createBookingLineCommand.Parameters.AddWithValue("ItemId", bookingLine.ItemsId);
                        try
                        {
                            createBookingLineCommand.ExecuteNonQuery();
                            numberOfRowsInserted++;
                        }
                        catch (Exception ex)
                        {
                            var res = ex;
                        }
                    }
                }

            }

            return numberOfRowsInserted;
        }


        // For some reason this does not work and I dont know why, it should work - Peter
        //public int Create(Booking booking)
        //{
        //    string bookingQuery = "INSERT INTO bookings(start_datetime, end_datetime, people_id, statuses_id) " +
        //                          "VALUES(@StartDateTime, @EndDateTime, @PersonId, @StatusId) SELECT scope_identity()";
        //    string bookingLineQuery = "INSERT INTO booking_line(bookings_id, items_id)" +
        //                              "VALUES(@BookingId, @ItemId)";

        //    int affectedRows = 0;
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {

        //            decimal insertedId = -1;
        //            using (SqlCommand createBookingCommand = conn.CreateCommand())
        //            {
        //                createBookingCommand.CommandText = bookingQuery;
        //                createBookingCommand.Parameters.AddWithValue("StartDateTime", booking.StartDatetime);
        //                createBookingCommand.Parameters.AddWithValue("EndDateTime", booking.EndDatetime);
        //                createBookingCommand.Parameters.AddWithValue("PersonId", booking.PeopleId);
        //                createBookingCommand.Parameters.AddWithValue("StatusId", booking.StatusesId);

        //                if (conn != null)
        //                {
        //                    try
        //                    {
        //                        conn.Open();

        //                        insertedId = (decimal)createBookingCommand.ExecuteScalar();
        //                        affectedRows++;
        //                    }
        //                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        //                }
        //                foreach (BookingLine bookingLine in booking.BookingLines)
        //                {
        //                    using (SqlCommand createBookingLineCommand = conn.CreateCommand())
        //                    {
        //                        createBookingLineCommand.CommandText = bookingLineQuery;
        //                        createBookingLineCommand.Parameters.AddWithValue("BookingId", insertedId);
        //                        createBookingLineCommand.Parameters.AddWithValue("ItemId", bookingLine.ItemsId);
        //                        try
        //                        {
        //                            createBookingLineCommand.ExecuteNonQuery();
        //                        }
        //                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }

        //                        affectedRows++;
        //                    }
        //                }



        //            }


        //        }
        //    }

        //    return affectedRows;
        //}

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
