using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_Client_WPF.Model
{
    public partial class Association
    {
        public Association()
        {
            AssociationPeople = new HashSet<AssociationPerson>();
            AssociationWarehouses = new HashSet<AssociationWarehouse>();
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Cvr { get; set; }
        public string Name { get; set; }
        public int AddressesId { get; set; }

        public virtual Address Addresses { get; set; }
        public virtual ICollection<AssociationPerson> AssociationPeople { get; set; }
        public virtual ICollection<AssociationWarehouse> AssociationWarehouses { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
