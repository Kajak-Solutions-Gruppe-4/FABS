using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.Model
{
    public partial class Address
    {
        public Address(string streetName, string streetNumber, string apartmentNumber, ZipcodeCountryCity zipcodeCountryCity) : this()
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
            ZipcodeCountryCity = zipcodeCountryCity;
            
        }

        public Address(string streetName, string streetNumber, string apartmentNumber, string zipcode, int countryId) :this()
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
            Zipcode = zipcode;
            CountriesId = countryId;
    

        }

        public override string ToString()
        {
            //return base.ToString();
            return StreetName + " " + StreetNumber + ", " + ApartmentNumber;
        }
    }
}
