using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Location
    {
        public Location(string pickLocation, string description) : this()
        {
            PickLocation = pickLocation;
            Description = description;
        }

        public Location(string pickLocation, int organisationsId) : this()
        {
            PickLocation = pickLocation;
            OrganisationsId = organisationsId;
        }

        public Location(string pickLocation, Organisation organisations) : this()
        {
            PickLocation = pickLocation;
            Organisations = organisations;
        }
    }
}