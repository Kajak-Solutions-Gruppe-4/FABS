
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_Web.Models
{
    public class PersonDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "telephoneNumber")]
        public string TelephoneNumber { get; set; }
        [JsonProperty(PropertyName = "address")]
        public AddressDto Address { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        public string FullAddress /*{ get; set; }*/
        {
            get
            {
                return FullAddress = GetFullAddress();
            }
            set
            {

            }
        }

        public PersonDto()
        {

        }
        public PersonDto(int id, string firstName, string lastName, string telephoneNumber, AddressDto address, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            Address = address;
            Email = email;
        }
        public PersonDto( string firstName, string lastName, string telephoneNumber, AddressDto address, string email)
        {
           
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            Address = address;
            Email = email;
        }


        // TODO: move to addressDto
        public string GetFullAddress()
        {
            string fullAddress = null;
            if (String.IsNullOrWhiteSpace(Address.ApartmentNumber))
            {
                fullAddress = Address.StreetName + " " + Address.StreetNumber;
            }
            else
            {
                fullAddress = Address.StreetName + " " + Address.StreetNumber + ", " + Address.ApartmentNumber;
            }
            return fullAddress;
        }

    }
}
