using System.ComponentModel.DataAnnotations;

namespace Business_logic.Model.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
