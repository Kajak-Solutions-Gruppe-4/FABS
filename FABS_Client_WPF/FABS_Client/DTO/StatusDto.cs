namespace FABS_Client_WPF.DTO
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