using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            ZipcodeCountryCities = new HashSet<ZipcodeCountryCity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ZipcodeCountryCity> ZipcodeCountryCities { get; set; }
    }
}
