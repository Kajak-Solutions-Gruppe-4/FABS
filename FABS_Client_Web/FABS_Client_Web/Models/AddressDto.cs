using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_Web.Models
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Zipcode { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public AddressDto()
        {

        }
        public AddressDto(int id, string streetName, string streetNumber, string apartmentNumber, string zipcode, int countryId, string country, string city)
        {
            Id = id;
            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
            Zipcode = zipcode;
            CountryId = countryId;
            Country = country;
            City = city;
        }
        public AddressDto(string streetName, string streetNumber, string apartmentNumber, string zipcode, int countryId, string country, string city)
        {

            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
            Zipcode = zipcode;
            CountryId = countryId;
            Country = country;
            City = city;
        }
        public AddressDto(string streetName, string streetNumber, string apartmentNumber, string zipcode, int countryId, string city)
        {

            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
            Zipcode = zipcode;
            CountryId = countryId;
            City = city;
        }
    }
}
