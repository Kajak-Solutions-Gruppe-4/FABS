using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Person
    {
        public Person()
        {
            Bookings = new HashSet<Booking>();
            Locations = new HashSet<Location>();
            OrganisationPeople = new HashSet<OrganisationPerson>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public int AdressesId { get; set; }
        public bool IsAdmin { get; set; }

        public virtual Address Addresses { get; set; }
        public virtual Login Login { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<OrganisationPerson> OrganisationPeople { get; set; }
    }
}
