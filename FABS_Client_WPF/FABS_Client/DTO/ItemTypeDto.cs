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
        [JsonProperty(PropertyName = "kayakTypes")]
        public KayakTypeDto KayakTypes { get; set; }

        public ItemTypeDto()
        {

        }

        //public ItemTypeDto(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}

        public ItemTypeDto(string name, KayakTypeDto kayakTypes)
        {
            Name = name;
            KayakTypes = kayakTypes;
        }

        public ItemTypeDto(int id, string name, KayakTypeDto kayakTypes)
        {
            Id = id;
            Name = name;
            KayakTypes = kayakTypes;
        }
    }
}