using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class KayakType
    {
        public KayakType(ItemType itemType, string decription, int weightLimit, decimal lengthMeter, int personCapacity)
        {
            ItemType = itemType;
            Description = decription;
            WeightLimit = weightLimit;
            LengthMeter = lengthMeter;
            PersonCapacity = personCapacity;
        }

        public KayakType(int itemTypeId, string decription, int weightLimit, decimal lengthMeter, int personCapacity)
        {
            ItemTypesId = itemTypeId;
            Description = decription;
            WeightLimit = weightLimit;
            LengthMeter = lengthMeter;
            PersonCapacity = personCapacity;
        }
    }
}
