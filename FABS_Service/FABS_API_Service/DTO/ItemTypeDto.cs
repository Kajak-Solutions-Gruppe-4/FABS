namespace FABS_API_Service.DTO
{
    public class ItemTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
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