using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_Client_WPF.DTO
{
    public class LocationDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "pickLocation")]
        public string PickLocation { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "warehouse")]
        public WarehouseDto Warehouse { get; set; }
        [JsonProperty(PropertyName = "people")]
        public PersonDto People { get; set; }
        [JsonProperty(PropertyName = "organisation")]
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
        public LocationDto(string pickLocation, string description)
        {
            PickLocation = pickLocation;
            Description = description;
        }
        public LocationDto(string description)
        {
            Description = description;
        }
    }
}
