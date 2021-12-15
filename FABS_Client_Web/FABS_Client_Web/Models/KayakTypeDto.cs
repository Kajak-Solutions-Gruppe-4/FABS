using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_Web.Models
{
    public class KayakTypeDto
    {
        public ItemTypeDto ItemTypesId { get; set; }
        public string Description { get; set; }
        public int WeightLimit { get; set; }
        public decimal LengthMeter { get; set; }
        public int PersonCapacity { get; set; }

        public KayakTypeDto()
        {

        }

        public KayakTypeDto(ItemTypeDto itemTypesId, string description, int weightLimit, decimal lengthMeter, int personCapacity)
        {
            ItemTypesId = itemTypesId;
            Description = description;
            WeightLimit = weightLimit;
            LengthMeter = lengthMeter;
            PersonCapacity = personCapacity;
        }

        public KayakTypeDto(string description, int weightLimit, decimal lengthMeter, int personCapacity)
        {
            Description = description;
            WeightLimit = weightLimit;
            LengthMeter = lengthMeter;
            PersonCapacity = personCapacity;
        }
    }
}
