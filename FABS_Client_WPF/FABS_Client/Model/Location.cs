using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_Client_WPF.Model
{
    public partial class Location
    {
        public Location()
        {
            Kayaks = new HashSet<Kayak>();
        }

        public int Id { get; set; }
        public string PickLocation { get; set; }
        public bool IsInUse { get; set; }
        public string Description { get; set; }
        public int WarehousesId { get; set; }
        public int? PeopleId { get; set; }

        public virtual Person People { get; set; }
        public virtual Warehouse Warehouses { get; set; }
        public virtual ICollection<Kayak> Kayaks { get; set; }
    }
}
