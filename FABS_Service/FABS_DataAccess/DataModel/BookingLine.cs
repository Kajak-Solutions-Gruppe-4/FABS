using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class BookingLine
    {
        public BookingLine()
        {
        }

        public BookingLine(Booking bookings, Item items) : this()
        {
            Bookings = bookings;
            Items = items;
        }

        public BookingLine(int bookingsId, int itemsId) : this()
        {
            BookingsId = bookingsId;
            ItemsId = itemsId;
        }

        public BookingLine(int bookingsId, Item items) : this()
        {
            BookingsId = bookingsId;
            Items = items;
        }
    }
}
