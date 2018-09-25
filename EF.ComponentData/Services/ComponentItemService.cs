using EF.ComponentData.Models;
using EF.ComponentData.Repositories;
using System.Collections.Generic;

namespace EF.ComponentData.Services
{
    /// <summary>
    /// Business layer service class for dealing with the component item repository.
    /// </summary>
    public class ComponentItemService : IComponentItemService
    {
        private readonly ItemRepository _itemRepository = new ItemRepository();

        /// <summary>
        /// Get a list of component items for a category.
        /// </summary>
        /// <param name="categoryCode">Component category code</param>
        /// <returns>A collection of component items</returns>
        public virtual IList<ComponentItem> GetComponentItemsByCategoryCode(string categoryCode)
        {
            return _itemRepository.FindAllComponentItemsByComponentCategoryCode(categoryCode);
        }

        /// <summary>
        /// Find a component item by its identifier
        /// </summary>
        /// <param name="componentId">Component identifier</param>
        /// <returns>Component item object corresponding to the identifier</returns>
        public virtual ComponentItem FindComponentById (int componentId)
        {
            return _itemRepository.FindById(componentId);
        }
    }
}
