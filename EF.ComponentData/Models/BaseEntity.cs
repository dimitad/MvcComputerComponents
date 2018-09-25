using System.ComponentModel.DataAnnotations;

namespace EF.ComponentData.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
