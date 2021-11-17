using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Organisation
    {
        public Organisation()
        {
            Items = new HashSet<Item>();
            Locations = new HashSet<Location>();
            OrganisationPeople = new HashSet<OrganisationPerson>();
        }

        public int Id { get; set; }
        public string Cvr { get; set; }
        public string Name { get; set; }
        public int AddressesId { get; set; }

        public virtual Address Addresses { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<OrganisationPerson> OrganisationPeople { get; set; }
    }
}
