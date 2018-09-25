using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF.ComponentData.Models
{
    public class ComponentItem : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public virtual ComponentCategory ComponentCategory { get; set; }

        public virtual ICollection<UserComponentSummary> UserComponentSummary { get; set; } = new HashSet<UserComponentSummary>();       
    }
}
