namespace FABS_API_Service.DTO
{
    public class ItemTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ItemTypeDto()
        {

        }

        public ItemTypeDto(string name)
        {
            Name = name;
        }
    }
}