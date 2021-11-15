using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Address
    {
        public Address()
        {
            Associations = new HashSet<Association>();
            People = new HashSet<Person>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

        public virtual ZipcodeCountryCity ZipcodeCountryCity { get; set; }
        public virtual ICollection<Association> Associations { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
