using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_Client_WPF.Model
{
    public partial class Booking
    {
        public Booking()
        {
            BookingLines = new HashSet<BookingLine>();
        }

        public int Id { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int PeopleId { get; set; }
        public int StatusesId { get; set; }

        public virtual Person People { get; set; }
        public virtual Status Statuses { get; set; }
        public virtual ICollection<BookingLine> BookingLines { get; set; }
    }
}
