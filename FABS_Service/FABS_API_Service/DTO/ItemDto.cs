using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_API_Service.DTO
{
    public class ItemDto
    {
        //TODO: Why id in the name of every property? They are objects. Not fixing now, because other solutions may use these names.
        public int Id { get; set; }
        public OrganisationDto OrganisationsId { get; set; }
        public StatusDto StatusesId { get; set; }
        public LocationDto LocationsId { get; set; }
        public ItemTypeDto ItemTypesId { get; set; }
        public int OrganisationsRealId { get; set; }
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

        public ItemDto(int organisationsRealId, ItemTypeDto itemTypesId)
        {
            OrganisationsRealId = organisationsRealId;
            ItemTypesId = itemTypesId;
        }
    }
}
