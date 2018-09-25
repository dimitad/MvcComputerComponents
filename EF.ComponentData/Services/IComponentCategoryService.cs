using System.Collections.Generic;
using EF.ComponentData.Models;

namespace EF.ComponentData.Services
{
    public interface IComponentCategoryService
    {
        IList<ComponentCategory> GetAllComponentCategories();
        ComponentCategory GetComponentCategoryByCode(string categoryCode);
    }
}