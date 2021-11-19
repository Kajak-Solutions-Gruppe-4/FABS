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
    }
}
