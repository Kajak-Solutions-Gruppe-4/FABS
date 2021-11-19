using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class ZipcodeCountryCity
    {
        public ZipcodeCountryCity(string zipcode, int country_id, string city) : this()
        {
            Zipcode = zipcode;
            CountriesId = country_id;
            City = city;
        }

        public ZipcodeCountryCity(string zipcode, Country country, string city)
        {
            Zipcode = zipcode;
            Countries = country;
            City = city;
        }
    }
}
