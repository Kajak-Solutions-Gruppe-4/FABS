using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Address
    {
        public Address(string streetName, string streetNumber, string apartmentNumber, ZipcodeCountryCity zipcodeCountryCity)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
            ZipcodeCountryCity = zipcodeCountryCity;
        }
    }
}
