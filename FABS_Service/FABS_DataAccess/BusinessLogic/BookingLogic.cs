using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Microsoft.Data.SqlClient;

namespace FABS_DataAccess.BusinessLogic
{
    public static class BookingLogic
    {
        /// <summary>
        /// Checks for past dates and if start and end date is correct 
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns>True if dates are correctly valdiated</returns>

        public static bool DateRangeValidator(DateTime date1, DateTime date2)
        {
            bool value = false;

            if (date1 < date2 && date1 >= DateTime.Now)
            {
                value = true;
            }
            return value;
        }

        /// <summary>
        /// Check if the incoming booking starttime and endtime has overlap in database
        /// </summary>
        /// <param name="connection">The connection DataBase</param>
        /// <param name="booking">The incoming booking</param>
        /// <returns>True if overlap exist, false if no overlap</returns>
        public static bool HasOverlap(SqlConnection connection, Booking booking)
        {
            SqlConnection conn = connection;
            bool isOverlapping = false;
            string futureItemBookingTimesQuery = "SELECT b.start_datetime, b.end_datetime, i.id " +
                                            "FROM bookings b, items i " +
                                            "WHERE b.id IN " +
                                            "(" +
                                            "SELECT bl.bookings_id " +
                                            "FROM booking_line bl " +
                                            "WHERE i.id = @ItemId " +
                                            "AND bl.items_id = i.id" +
                                            ") " +
                                            "AND b.end_datetime > GETDATE()";
            if (conn != null)
            {


                foreach (var bookingLine in booking.BookingLines)
                {
                    using (SqlCommand futureItemBookingTimesCommand = new SqlCommand(futureItemBookingTimesQuery, conn))
                    {
                        futureItemBookingTimesCommand.Parameters.AddWithValue("ItemId", bookingLine.ItemsId);

                        using (var bookingTimesReader = futureItemBookingTimesCommand.ExecuteReader())
                        {
                            DateTime startDateTime;
                            DateTime endDateTime;

                            while (bookingTimesReader.Read())
                            {
                                startDateTime = bookingTimesReader.GetDateTime(bookingTimesReader.GetOrdinal("start_datetime"));
                                endDateTime = bookingTimesReader.GetDateTime(bookingTimesReader.GetOrdinal("end_datetime"));

                                if (new[] { startDateTime, booking.StartDatetime }.Max() < new[] { endDateTime, booking.EndDatetime }.Min())
                                {
                                    isOverlapping = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return isOverlapping;
        }
    }
}

