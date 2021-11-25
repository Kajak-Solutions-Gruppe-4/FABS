using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_Client_WPF.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string PickLocation { get; set; }
        public string Description { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public PersonDto People { get; set; }
        public OrganisationDto Organisation { get; set; }

        public LocationDto()
        {

        }

        public LocationDto(int id, string pickLocation, string description, WarehouseDto warehouseDto, PersonDto peopleDto, OrganisationDto organisationDto)
        {
            Id = id;
            PickLocation = pickLocation;
            Description = description;
            Warehouse = warehouseDto;
            People = peopleDto;
            Organisation = organisationDto;

        }

        public LocationDto(string pickLocation, string description, WarehouseDto warehouseDto, PersonDto peopleDto, OrganisationDto organisationDto)
        {
            PickLocation = pickLocation;
            Description = description;
            Warehouse = warehouseDto;
            People = peopleDto;
            Organisation = organisationDto;
        }
    }
}
