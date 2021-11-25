using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_Client_WPF.DTO
{
    public class OrganisationDto
    {
        public int Id { get; set; }
        public string Cvr { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }

        public OrganisationDto()
        {

        }

        public OrganisationDto(int id, string cvr, string name, AddressDto address)
        {
            Id = id;
            Cvr = cvr;
            Name = name;
            Address = address;
        }

        public OrganisationDto(string cvr, string name, AddressDto address)
        {
            Cvr = cvr;
            Name = name;
            Address = address;
        }

        public OrganisationDto(string cvr, string name)
        {
            Cvr = cvr;
            Name = name;
        }
        public OrganisationDto(int id, string cvr, string name)
        {
            Id = id;
            Cvr = cvr;
            Name = name;
        }
    }
}

