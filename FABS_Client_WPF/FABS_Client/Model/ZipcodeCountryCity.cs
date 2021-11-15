using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_Client_WPF.Model
{
    public partial class ZipcodeCountryCity
    {
        public ZipcodeCountryCity()
        {
            Addresses = new HashSet<Address>();
        }

        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
