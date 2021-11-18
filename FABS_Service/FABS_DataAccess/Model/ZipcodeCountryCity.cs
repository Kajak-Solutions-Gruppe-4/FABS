using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class ZipcodeCountryCity
    {
        public ZipcodeCountryCity()
        {
            Addresses = new HashSet<Address>();
        }

        public string Zipcode { get; set; }
        public int CountriesId { get; set; }
        public string City { get; set; }

        public virtual Country Countries { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
