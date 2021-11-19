using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Item
    {
        public Item(int organisationsId, int itemTypesId) : this()
        {
            OrganisationsId = organisationsId;
            ItemTypesId = itemTypesId;
        }

        public Item(int organisationsId, ItemType itemTypes) : this()
        {
            OrganisationsId = organisationsId;
            ItemTypes = itemTypes;
        }

        public Item(Organisation organisations, ItemType itemTypes) : this()
        {
            Organisations = organisations;
            ItemTypes = itemTypes;
        }

        public Item(Organisation organisations, int itemTypesId) : this()
        {
            Organisations = organisations;
            ItemTypesId = itemTypesId;
        }
    }
}
