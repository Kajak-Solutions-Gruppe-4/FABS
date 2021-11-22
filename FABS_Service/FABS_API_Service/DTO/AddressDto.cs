using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_API_Service.DTO
{
    class AddressDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public AddressDto(int id, string streetName, string streetNumber, string apartmentNumber, string zipcode, string country, string city)
        {
            Id = id;
            StreetName = streetName;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
            Zipcode = zipcode;
            Country = country;
            City = city;
        }
    }
}
