using EF.ComponentData.Models;
using System.Data.Entity;

namespace EF.ComponentData.DbContexts
{
    /// <summary>
    /// Primary component class for interfacing with the database
    /// </summary>
    public class ComponentEntities : DbContext
    {
        public ComponentEntities()
            : base("name=ComponentEntities")
        {
        }

        public virtual DbSet<ComponentItem> ComponentItems { get; set; }

        public virtual DbSet<ComponentCategory> ComponentCategory { get; set; }

        public virtual DbSet<UserComponentSummary> UserComponentSummary { get; set; }
    }
}