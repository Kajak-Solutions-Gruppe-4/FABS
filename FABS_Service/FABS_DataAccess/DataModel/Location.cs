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
            Warehouses = warehouse;
            People = person;
            Organisations = organisation;

        }

        public Location(string pickLocation, Organisation organisations) : this()
        {
            PickLocation = pickLocation;
            Organisations = organisations;
        }


    }
}