using Newtonsoft.Json;

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
    }
}