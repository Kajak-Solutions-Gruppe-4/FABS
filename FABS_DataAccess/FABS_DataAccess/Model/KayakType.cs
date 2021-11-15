using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class KayakType
    {
        public KayakType()
        {
            Kayaks = new HashSet<Kayak>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeightLimit { get; set; }
        public decimal LengthMeter { get; set; }
        public int PersonCapacity { get; set; }

        public virtual ICollection<Kayak> Kayaks { get; set; }
    }
}
