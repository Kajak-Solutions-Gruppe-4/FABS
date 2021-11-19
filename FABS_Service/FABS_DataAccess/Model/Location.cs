using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Location
    {
        public Location()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string PickLocation { get; set; }
        public string Description { get; set; }
        public int? WarehousesId { get; set; }
        public int? PeopleId { get; set; }
        public int OrganisationsId { get; set; }

        public virtual Organisation Organisations { get; set; }
        public virtual Person People { get; set; }
        public virtual Warehouse Warehouses { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
