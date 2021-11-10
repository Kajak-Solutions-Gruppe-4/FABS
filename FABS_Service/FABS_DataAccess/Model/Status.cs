using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Status
    {
        public Status()
        {
            Bookings = new HashSet<Booking>();
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
