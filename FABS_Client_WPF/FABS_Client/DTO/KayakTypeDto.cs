using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.DTO
{
    public class KayakTypeDto
    {
        [JsonProperty(PropertyName = "itemTypesId")]
        public ItemTypeDto ItemTypesId { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "weightLimit")]
        public int WeightLimit { get; set; }
        [JsonProperty(PropertyName = "lengthMeter")]
        public decimal LengthMeter { get; set; }
        [JsonProperty(PropertyName = "personCapacity")]
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
