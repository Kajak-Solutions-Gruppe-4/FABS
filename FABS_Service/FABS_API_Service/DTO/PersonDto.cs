using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_API_Service.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public AddressDto Address { get; set; }
        public string Email { get; set; }

        public PersonDto(int id, string firstName, string lastName, string telephoneNumber, AddressDto address, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            Address = address;
            Email = email;
        }
    }
}
