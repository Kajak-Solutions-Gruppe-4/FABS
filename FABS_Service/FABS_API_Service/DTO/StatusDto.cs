namespace FABS_API_Service.DTO
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
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