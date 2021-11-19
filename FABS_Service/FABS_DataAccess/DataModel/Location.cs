using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Location
    {
        public Location(string pickLocation, bool isInUse, string description, Warehouse warehouse, Person person, Organisation organisation)
        {
            PickLocation = pickLocation;
            IsInUse = isInUse;
            Description = description;
            Warehouses = warehouse;
            People = person;
            Organisations = organisation;
        }
    }
}