using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            AssociationWarehouses = new HashSet<AssociationWarehouse>();
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressesId { get; set; }

        public virtual Address Addresses { get; set; }
        public virtual ICollection<AssociationWarehouse> AssociationWarehouses { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}