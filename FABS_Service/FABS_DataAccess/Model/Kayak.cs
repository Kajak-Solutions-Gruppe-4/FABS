using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Kayak
    {
        public int ItemsId { get; set; }
        public string Serial { get; set; }
        public int KayakTypesId { get; set; }
        public int LocationsId { get; set; }

        public virtual KayakType KayakTypes { get; set; }
        public virtual Location Locations { get; set; }
        public virtual Item Item { get; set; }
    }
}
