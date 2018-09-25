using System;
using EF.ComponentData.Models;
using System.Collections.Generic;
using System.Linq;

namespace EF.ComponentData.Repositories
{
    /// <summary>
    /// Item repository class for managing individual component items.
    /// </summary>
    public class ItemRepository : BaseRepository<ComponentItem>
    {
        /// <summary>
        /// Find a list of components for a given category.
        /// </summary>
        /// <param name="categoryCode">Component category code that user has selected</param>
        /// <returns>A collection of components</returns>
        public virtual IList<ComponentItem> FindAllComponentItemsByComponentCategoryCode(string categoryCode)
        {
            return DbContext.Set<ComponentItem>().Where(item => item.ComponentCategory.CategoryCode.Equals(categoryCode, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
