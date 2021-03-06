using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_API_Service.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string PickLocation { get; set; }
        public string Description { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public PersonDto People { get; set; }
        public OrganisationDto Organisation { get; set; }

        public LocationDto(string pickLocation, string description, PersonDto people, OrganisationDto organisation)
        {
            PickLocation = pickLocation;
            Description = description;
            People = people;
            Organisation = organisation;
        }

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

        public LocationDto(int id, string pickLocation, string description)
        {
            Id = id;
            PickLocation = pickLocation;
            Description = description;
        }

        public LocationDto(int id, string pickLocation, string description, PersonDto people, OrganisationDto organisation)
        {
            Id = id;
            PickLocation = pickLocation;
            Description = description;
            People = people;
            Organisation = organisation;
        }
    }
}
