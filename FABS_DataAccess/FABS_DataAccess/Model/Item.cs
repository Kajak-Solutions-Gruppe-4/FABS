using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Item
    {
        public Item()
        {
            BookingLines = new HashSet<BookingLine>();
        }

        public int Id { get; set; }
        public int AssociationId { get; set; }
        public int StatusesId { get; set; }

        public virtual Association Association { get; set; }
        public virtual Kayak IdNavigation { get; set; }
        public virtual Status Statuses { get; set; }
        public virtual ICollection<BookingLine> BookingLines { get; set; }
    }
}
