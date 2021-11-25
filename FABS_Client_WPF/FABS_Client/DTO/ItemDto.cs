using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.DTO
{
    class ItemDto
    {
        public int Id { get; set; }
        public OrganisationDto OrganisationsId { get; set; }
        public StatusDto StatusesId { get; set; }
        public LocationDto LocationsId { get; set; }
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

        public ItemDto(int id, OrganisationDto organisationId, StatusDto statusId, LocationDto locationId, ItemTypeDto itemTypeId)
        {
            Id = id;
            OrganisationsId = organisationId;
            StatusesId = statusId;
            LocationsId = locationId;
            ItemTypesId = itemTypeId;
        }
    }
}

