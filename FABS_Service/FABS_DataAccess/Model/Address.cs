using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Address
    {
        public Address()
        {
            Organisations = new HashSet<Organisation>();
            People = new HashSet<Person>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Zipcode { get; set; }
        public int CountriesId { get; set; }

        public virtual Country Countries { get; set; }
        public virtual ZipcodeCountryCity ZipcodeCountryCity { get; set; }
        public virtual ICollection<Organisation> Organisations { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
