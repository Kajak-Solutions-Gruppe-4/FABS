using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.DTO
{
    class ItemDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "organisationsId")]
        public OrganisationDto OrganisationsId { get; set; }
        [JsonProperty(PropertyName = "statusesId")]
        public StatusDto StatusesId { get; set; }
        [JsonProperty(PropertyName = "locationsId")]
        public LocationDto LocationsId { get; set; }
        [JsonProperty(PropertyName = "itemTypesId")]
        public ItemTypeDto ItemTypesId { get; set; }

        public ItemDto()
        {

        }

        public ItemDto(OrganisationDto organisationsId, StatusDto statusesId, LocationDto locationsId, ItemTypeDto itemTypesId)
        {
            OrganisationsId = organisationsId;
            StatusesId = statusesId;
            LocationsId = locationsId;
            ItemTypesId = itemTypesId;
        }

        public ItemDto(OrganisationDto organisationsId, StatusDto statusesId, ItemTypeDto itemTypesId)
        {
            OrganisationsId = organisationsId;
            StatusesId = statusesId;
            ItemTypesId = itemTypesId;
        }

        public ItemDto(int id, StatusDto statusesId, LocationDto locationsId, ItemTypeDto itemTypesId)
        {
            Id = id;
            StatusesId = statusesId;
            LocationsId = locationsId;
            ItemTypesId = itemTypesId;
        }
    


        public ItemDto(int id, OrganisationDto organisationId, StatusDto statusId, LocationDto locationId, ItemTypeDto itemTypeId)
        {
            Id = id;
            OrganisationsId = organisationId;
            StatusesId = statusId;
            LocationsId = locationId;
            ItemTypesId = itemTypeId;
        }

        public ItemDto(LocationDto location, ItemTypeDto itemType)
        {
            LocationsId = location;
            ItemTypesId = itemType;
        }

    }
}

