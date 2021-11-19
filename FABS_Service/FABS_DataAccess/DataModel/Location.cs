using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Location
    {
        public Location(string pickLocation, bool isInUse, string description)
        {
            PickLocation = pickLocation;
            IsInUse = isInUse;
            Description = description;
        }
    }
}