using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.ComponentData.Models
{
    [Table("UserComponentSummary")]
    public class UserComponentSummary : BaseEntity
    {
        [Required]
        public System.Guid UserId { get; set; }
        
        public virtual ComponentItem ComponentItem { get; set; }
    }
}
