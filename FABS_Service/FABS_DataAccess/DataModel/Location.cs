using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Location
    {
        public Location(string pickLocation, string description, Warehouse warehouse, Person person, Organisation organisation) : this()
        {
            PickLocation = pickLocation;
            Description = description;
        }

        public Location(string pickLocation, int organisationsId, Warehouse warehouse, Person person, Organisation organisation) : this()
        {
            PickLocation = pickLocation;
            OrganisationsId = organisationsId;
        }

        public Location(string pickLocation, Organisation organisations, Warehouse warehouse, Person person, Organisation organisation) : this()
        {
            PickLocation = pickLocation;
            Organisations = organisations;
        }
    }
}