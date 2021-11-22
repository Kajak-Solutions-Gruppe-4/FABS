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
        
        public Item(Organisation organisation, int statusId, Location location, ItemType itemType) : this()
        {
            Organisations = organisation;
            StatusesId = statusId;
            Locations = location;
            ItemTypes = itemType;
        }

        public Item(Organisation organisations, int itemTypesId) : this()
        {
            Organisations = organisations;
            ItemTypesId = itemTypesId;
        }

        public Item(int organisationsId, ItemType itemTypes) : this()
        {
            OrganisationsId = organisationsId;
            ItemTypes = itemTypes;
        }

        public Item(int organisationsId, int itemTypesId) : this()
        {
            OrganisationsId = organisationsId;
            ItemTypesId = itemTypesId;
        }

        public Item(ItemType itemTypes, Organisation organisations) : this()
        {
            ItemTypes = itemTypes;
            Organisations = organisations;
        }
    }
}
