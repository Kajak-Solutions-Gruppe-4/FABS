using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.Model
{
    public partial class ZipcodeCountryCity
    {
        public ZipcodeCountryCity(string zipcode, string country, string city) : this()
        {
            Zipcode = zipcode;
            Country = country;
            City = city;
        }
    }
}
