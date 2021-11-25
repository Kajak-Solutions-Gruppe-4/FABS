using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_API_Service.DTO
{
    public class ItemDto
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
    }
}
