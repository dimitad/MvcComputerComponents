using System;
using EF.ComponentData.Models;
using EF.ComponentData.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace EF.ComponentData.Services
{
    /// <summary>
    /// Business layer service class for dealing with the component category repository.
    /// </summary>
    public class ComponentCategoryService : IComponentCategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();

        /// <summary>
        /// Find all component categories configured in the database
        /// </summary>
        /// <returns>A collection of the component categories</returns>
        public virtual IList<ComponentCategory> GetAllComponentCategories()
        {
            return _categoryRepository.FindAll().OrderBy(c => c.Position).ToList();
        }

        /// <summary>
        /// Find a component category by its code
        /// </summary>
        /// <param name="categoryCode">Component category code</param>
        /// <returns>Component category object corresponding to the code</returns>
        public virtual ComponentCategory GetComponentCategoryByCode(string categoryCode)
        {
            return _categoryRepository.FindAll().Where(c => c.CategoryCode.Equals(categoryCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

    }
}
