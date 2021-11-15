using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class BookingLine
    {
        public int Id { get; set; }
        public int BookingsId { get; set; }
        public int ItemsId { get; set; }

        public virtual Booking Bookings { get; set; }
        public virtual Item Items { get; set; }
    }
}
