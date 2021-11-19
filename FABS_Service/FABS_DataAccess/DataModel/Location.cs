using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Location
    {
        public Location(string pickLocation, string description)
        {
            PickLocation = pickLocation;
            Description = description;
        }
    }
}