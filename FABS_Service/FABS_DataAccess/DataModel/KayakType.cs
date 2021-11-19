using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class KayakType
    {
        public KayakType()
        {
        }

        public KayakType(string description, int weightLimit, decimal lengthMeter, int personCapacity, ItemType itemType) : this()
        {
            Description = description;
            WeightLimit = weightLimit;
            LengthMeter = lengthMeter;
            PersonCapacity = personCapacity;
            ItemType = itemType;
        }
    }
}
