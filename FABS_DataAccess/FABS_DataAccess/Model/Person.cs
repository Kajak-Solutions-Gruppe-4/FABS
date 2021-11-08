using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Person
    {
        public Person()
        {
            AssociationPeople = new HashSet<AssociationPerson>();
            Bookings = new HashSet<Booking>();
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        [Required]
        public int AdressesId { get; set; }
        [Required]
        public int LoginsId { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        public virtual Address Adresses { get; set; }
        public virtual Login Logins { get; set; }
        public virtual ICollection<AssociationPerson> AssociationPeople { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
