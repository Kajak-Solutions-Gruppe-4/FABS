using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace FABS_Client_WPF.DTO
{
    public class ItemTypeDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "kayakType")]
        public KayakTypeDto KayakType { get; set; }
        public KayakTypeDto KayakTypesId { get; set; }

        public ItemTypeDto()
        {

        }

        public ItemTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ItemTypeDto(int id, string name, KayakTypeDto kayakType)
        {
            Id = id;
            Name = name; 
            KayakType = kayakType;
        }

        public ItemTypeDto(string name, KayakTypeDto kayakType)
        {
            Name = name;
            KayakTypesId = kayakType;
        }
    }
}