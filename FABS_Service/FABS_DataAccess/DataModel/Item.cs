using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Item
    {
        public Item(Organisation organisation, Status status, Location location, ItemType itemType) : this()
        {
            Organisations = organisation;
            Statuses = status;
            Locations = location;
            ItemTypes = itemType;
        }

        public Item(int organisationId, int statusId, int locationId, int itemTypeId) : this()
        {
            OrganisationsId = organisationId;
            StatusesId = statusId;
            LocationsId = locationId;
            ItemTypesId = itemTypeId;
        }

    }
}
