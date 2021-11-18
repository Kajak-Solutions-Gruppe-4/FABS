using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class PersonView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public int AdressesId { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int OrganisationsId { get; set; }
        public string OrganisationCvr { get; set; }
        public string OrganisationName { get; set; }
    }
}
