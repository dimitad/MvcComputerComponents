using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.ComponentData.Models
{
    [Table("ComponentCategory")]
    public class ComponentCategory : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(50)]
        public string CategoryCode { get; set; }

        public int Position { get; set; }

        public virtual ICollection<ComponentItem> ComponentItems { get; set; } = new HashSet<ComponentItem>();
    }
}
