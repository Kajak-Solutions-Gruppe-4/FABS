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

        /// <summary>
        /// Creates BookingRepository which uses local database
        /// </summary>
        public BookingRepository()
        {
            Initialize("Local");
        }

        /// <summary>
        /// Creates BookingRepository
        /// </summary>
        /// <param name="nameOfConnectionString">the name og the connectionstring to use</param>
        public BookingRepository(string nameOfConnectionString)
        {
            Initialize(nameOfConnectionString);
        }

        /// <summary>
        /// Calling up the path for a connection to the database
        /// </summary>
        /// <param name="nameOfConnectionString"></param>
        private void Initialize(string nameOfConnectionString)
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
            _connectionString = Configuration.GetConnectionString(nameOfConnectionString);
        }

        /// <summary>
        /// This method Creates booking in the database, if data is correct and there is no overlap between bookings and their items
        /// </summary>
        /// <param name="booking">The incoming booking with items</param>
        /// <returns>Number of rows affected, or 0 if no rows have been written in DB (not successfull)</returns>
        public int Create(Booking booking)
        {
            int numberOfRowsInserted = 0;

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
            var transactionOptions = new TransactionOptions();
            //transactionOptions.IsolationLevel = IsolationLevel.RepeatableRead; Not strong enough
            transactionOptions.IsolationLevel = IsolationLevel.Serializable;
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    bool allSuccessfull = true;
                    decimal insertedBookingId = -1;
                    conn.Open();
                    if (BookingLogic.HasAnyOverlap(conn, booking))
                    {
                        return numberOfRowsInserted;
                    }
                    // Prepare command for inserting booking
                    string bookingQuery = "INSERT INTO bookings(start_datetime, end_datetime, people_id, statuses_id) " +
                                         "VALUES(@StartDateTime, @EndDateTime, @PersonId, @StatusId) SELECT scope_identity()";
                    // Prepare command for inserting bookinglines
                    //TODO: Validate item availability in SQL string
                    string bookingLineQuery = "INSERT INTO booking_line(bookings_id, items_id)" +
                                              "VALUES(@BookingId, @ItemId)";

                    using SqlCommand insertBookingCommand = new SqlCommand(bookingQuery, conn);

                    insertBookingCommand.Parameters.AddWithValue("StartDateTime", booking.StartDatetime);
                    insertBookingCommand.Parameters.AddWithValue("EndDateTime", booking.EndDatetime);
                    insertBookingCommand.Parameters.AddWithValue("PersonId", booking.PeopleId);
                    insertBookingCommand.Parameters.AddWithValue("StatusId", booking.StatusesId);

                    try
                    {
                        insertedBookingId = (decimal)insertBookingCommand.ExecuteScalar();
                        numberOfRowsInserted++;
                    }
                    catch (SqlException e)
                    {
                        allSuccessfull = false;
                    }

                    foreach (BookingLine bookingLine in booking.BookingLines)
                    {
                        using SqlCommand createBookingLineCommand = new SqlCommand(bookingLineQuery, conn);


                        createBookingLineCommand.Parameters.AddWithValue("BookingId", insertedBookingId);
                        createBookingLineCommand.Parameters.AddWithValue("ItemId", bookingLine.ItemsId);
                        try
                        {
                            numberOfRowsInserted += createBookingLineCommand.ExecuteNonQuery();
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
            }
            return numberOfRowsInserted;
        }



        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Getting a specific booking belonging to a certain member.
        /// Shall be refactored to a list over the members bookings.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="organisationId"></param>
        /// <returns>A single booking object</returns>
        public Booking Get(int id, int organisationId)
        {
            Booking booking = new Booking();
            try
            {
                string query = "SELECT bookings.id AS \"booking_id\", bookings.start_datetime, bookings.end_datetime, people.id AS \"people_id\", " +
                    "bookings.statuses_id AS \"booking_statuses_id\", booking_line.items_id FROM booking_line " +
                    "INNER JOIN bookings ON booking_line.bookings_id = bookings.id " +
                    "INNER JOIN people ON bookings.people_id = people.id " +
                    "INNER JOIN items ON booking_line.items_id = items.id " +
                    "where bookings_id = @BookingId";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(query, conn))
                {
                    if (conn != null)
                    {
                        conn.Open();
                        readCommand.Parameters.AddWithValue("BookingId", id);
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
        
        /// <summary>
        /// Generating a list of all bookings in the database
        /// </summary>
        /// <param name="organisationId"></param>
        /// <returns>List a list of bookings</returns>
        public IEnumerable<Booking> GetAll(int organisationId)
        {
            //throw new NotImplementedException();
            IEnumerable<Booking> listBooking = null;

            try
            {
                //TODO: WHERE clause for organisation ID so we can information hide based on organsation
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

        /// <summary>
        /// This method gets all booking objects in the database.
        /// </summary>
        /// <param name="bookingReader"></param>
        /// <returns>A list of bookings</returns>
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

        /// <summary>
        /// This method finds a single booking in the database.
        /// </summary>
        /// <param name="bookingReader"></param>
        /// <returns>A single booking object</returns>
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

        /// <summary>
        /// Finds all future bookings that does not overlap a date range.
        /// </summary>
        /// <param name="startDatetime">The beginning of the date range</param>
        /// <param name="endDatetime">The beginning of the date range</param>
        /// <param name="organisationId">The id of the organisation to find bookings from</param>
        /// <returns>A list of bookings that does not overlap the date range</returns>
        public List<Booking> FindNotOverlappingFutureBookingsInDaterange(DateTime startDatetime, DateTime endDatetime, int organisationId)
        {
            List<Booking> futureBookings = FindAllFutureBookings(organisationId);
            List<Booking> availableBookings = new List<Booking>();
            foreach (Booking booking in futureBookings)
            {
                if (!BookingLogic.IsBookingOverlappingDateRange(booking, startDatetime, endDatetime) && BookingLogic.DateRangeValidator(startDatetime, endDatetime))
                {
                    availableBookings.Add(booking);
                }
            }
            return availableBookings;
        }

        /// <summary>
        /// Finds all future bookings that does overlap a date range.
        /// </summary>
        /// <param name="startDatetime">The beginning of the date range</param>
        /// <param name="endDatetime">The beginning of the date range</param>
        /// <param name="organisationId">The id of the organisation to find bookings from</param>
        /// <returns>A list of bookings that does not overlap the date range</returns>
        public List<Booking> FindOverlappingFutureBookingsInDaterange(DateTime startDatetime, DateTime endDatetime, int organisationId)
        {
            List<Booking> futureBookings = FindAllFutureBookings(organisationId);
            List<Booking> overlappingBookings = new List<Booking>();
            foreach (Booking booking in futureBookings)
            {
                if (BookingLogic.IsBookingOverlappingDateRange(booking, startDatetime, endDatetime))
                {
                    overlappingBookings.Add(booking);
                }
            }
            return overlappingBookings;
        }

        /// <summary>
        /// Find all bookings in the future in an organisation.
        /// </summary>
        /// <param name="organisationId">The id of an organisation</param>
        /// <returns>A list of the bookings in the future, containing the items</returns>
        public List<Booking> FindAllFutureBookings(int organisationId)
        {
            string sqlQuery = "SELECT b.start_datetime, b.end_datetime, b.people_id, b.statuses_id, bl.bookings_id, bl.items_id, " +
                                  "it.name AS 'item_type_name', it.id AS 'item_type_id', " +
                                  "kt.description, kt.weight_limit, kt.length_meter, kt.person_capacity " +
                              "FROM bookings b " +
                              "JOIN booking_line bl ON bl.bookings_id = b.id " +
                              "JOIN items i ON bl.items_id = i.id " +
                              "JOIN item_types it ON i.item_types_id = it.id " +
                              "JOIN kayak_types kt ON it.id = kt.item_types_id " +
                              "WHERE bl.items_id IN " +
                              "( " +
                                  "SELECT i.id " +
                                  "FROM items i " +
                                  "WHERE i.organisations_id = @OrganisationId " +
                              ") " +
                              "AND GETDATE() < b.end_datetime";

            List<Booking> bookingList = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn != null)
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = sqlQuery;
                        command.Parameters.AddWithValue("OrganisationId", organisationId);

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                DateTime startDatetime = dataReader.GetDateTime(dataReader.GetOrdinal("start_datetime"));
                                DateTime endDatetime = dataReader.GetDateTime(dataReader.GetOrdinal("end_datetime"));
                                int personId = dataReader.GetInt32(dataReader.GetOrdinal("people_id"));
                                int statusesId = dataReader.GetInt32(dataReader.GetOrdinal("statuses_id"));
                                int bookingId = dataReader.GetInt32(dataReader.GetOrdinal("bookings_id"));
                                int itemId = dataReader.GetInt32(dataReader.GetOrdinal("items_id"));
                                string itemTypeName = dataReader.GetString(dataReader.GetOrdinal("item_type_name"));
                                int itemTypeId = dataReader.GetInt32(dataReader.GetOrdinal("item_type_Id"));
                                string kayakTypeDescription = dataReader.GetString(dataReader.GetOrdinal("description"));
                                int kayakTypeWeight = dataReader.GetInt32(dataReader.GetOrdinal("weight_limit"));
                                decimal kayakTypeLength = dataReader.GetDecimal(dataReader.GetOrdinal("length_meter"));
                                int kayakTypeCapacity = dataReader.GetInt32(dataReader.GetOrdinal("person_capacity"));

                                ItemType itemType = new ItemType(itemTypeName);
                                itemType.Id = itemTypeId;
                                KayakType kayakType = new KayakType(kayakTypeDescription, kayakTypeWeight, kayakTypeLength, kayakTypeCapacity, itemType);
                                kayakType.ItemTypesId = itemTypeId;
                                itemType.KayakType = kayakType;

                                Item item = new Item(organisationId, itemType);
                                item.Id = itemId;
                                itemType.Items.Add(item);

                                BookingLine bookingLine = new BookingLine(bookingId, item);
                                if (!bookingList.Any(b => b.Id == bookingId))
                                {
                                    Booking booking = new Booking(startDatetime, endDatetime, personId, statusesId);
                                    booking.BookingLines.Add(bookingLine);
                                    bookingList.Add(booking);
                                }
                                else
                                {
                                    bookingList.Where(b => b.Id == bookingId)
                                               .Single()
                                               .BookingLines
                                               .Add(bookingLine);
                                }

                            }

                        }
                    }
                }

            }
            return bookingList;
        }
    }
}
