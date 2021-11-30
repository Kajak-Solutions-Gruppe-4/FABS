using Newtonsoft.Json;

namespace FABS_Client_WPF.DTO
{
    public class StatusDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        public StatusDto()
        {

        }

        public StatusDto(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}