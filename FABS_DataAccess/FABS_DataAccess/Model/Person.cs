using System;
using System.Collections.Generic;

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

        public Person(string firstName, string lastName, int addressId, int loginId, bool isAdmin) : this()
        {
            
            FirstName = firstName;
            LastName = lastName;
            AdressesId = addressId;
            LoginsId = loginId;
            IsAdmin = isAdmin;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public int AdressesId { get; set; }
        public int LoginsId { get; set; }
        public bool IsAdmin { get; set; }

        public virtual Address Adresses { get; set; }
        public virtual Login Logins { get; set; }
        public virtual ICollection<AssociationPerson> AssociationPeople { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
